using Shooter.Core;
using Shooter.Hand;
using Shooter.HP;
using Shooter.Services;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : Controller<PlayerModel, PlayerView>, ITickable
    {
        private readonly ShooterInputActions inputActions;
        
        private readonly HandController handController;
        private readonly HPController hpController;

        public PlayerController(ItemsService itemsService, ShooterInputActions inputActions)
        {
            this.inputActions = inputActions;

            handController = new HandController(itemsService);
            handController.SetModel(new HandModel());

            hpController = new HPController();
            
            inputActions.Player.UseItem.started += UseItemOnStarted;
            inputActions.Player.UseItem.canceled += UseItemOnCanceled;
        }

        public void Tick()
        {
            if (Model == null || View == null)
            {
                return;
            }

            var moveDirection = inputActions.Player.Move.ReadValue<Vector2>();
            View.SetMoveVelocity(moveDirection * Model.MoveSpeed);

            var lookDelta = inputActions.Player.Look.ReadValue<Vector2>();
            var lookDeltaScreenNormalized = new Vector2(lookDelta.x / Screen.width, lookDelta.y / Screen.height);
            
            View.Rotate(lookDeltaScreenNormalized * Model.RotationSpeed);
        }

        public void AddSkillPoint()
        {
            Model.StatsModel.AvailablePoints++;
        }

        protected override void OnModelChanged()
        {
            handController.TakeItem(Model.ItemModel);
            hpController.SetModel(Model.HPModel);
        }

        protected override void OnBeforeViewChanged()
        {
            if (View == null)
            {
                return;
            }
            
            View.DamageTaken -= ViewOnDamageTaken;
        }

        protected override void OnViewChanged()
        {
            if (View == null)
            {
                return;
            }
            
            handController.SetView(View.GetComponentInChildren<HandView>());
            hpController.SetView(View.GetComponentInChildren<HPView>());

            View.DamageTaken += ViewOnDamageTaken;
        }

        private void ViewOnDamageTaken(float damage)
        {
            hpController.RemoveHP(damage);
        }

        private void UseItemOnStarted(InputAction.CallbackContext context)
        {
            handController.StartUseItem();
        }

        private void UseItemOnCanceled(InputAction.CallbackContext context)
        {
            handController.StopUseItem();
        }
    }
}