using Shooter.Core;
using UnityEngine;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : Controller<PlayerModel, PlayerView>, ITickable
    {
        private readonly ShooterInputActions inputActions;

        public PlayerController(ShooterInputActions inputActions)
        {
            this.inputActions = inputActions;
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
    }
}