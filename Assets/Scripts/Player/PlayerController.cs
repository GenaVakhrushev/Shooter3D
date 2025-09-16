using Shooter.Core;
using Shooter.Hand;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : Controller<PlayerModel, PlayerView>, ITickable
    {
        private readonly ShooterInputActions inputActions;
        
        private readonly HandController handController;

        public PlayerController(ShooterInputActions inputActions)
        {
            this.inputActions = inputActions;

            handController = new HandController();
            handController.SetModel(new HandModel());
            
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

        protected override void OnModelChanged()
        {
            handController.TakeItem(Model.ItemModel);
        }

        protected override void OnViewChanged()
        {
            if (View == null)
            {
                return;
            }
            
            handController.SetView(View.GetComponentInChildren<HandView>());
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