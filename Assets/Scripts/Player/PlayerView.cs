using Shooter.Core;
using UnityEngine;

namespace Shooter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : View
    {
        [SerializeField] private Transform cameraRoot;

        private float cameraRootAngle;
        
        private Rigidbody rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetMoveVelocity(Vector2 moveVelocity)
        {
            var velocityWorld = transform.TransformVector(new Vector3(moveVelocity.x, 0, moveVelocity.y));
            rb.velocity = new Vector3(velocityWorld.x, rb.velocity.y, velocityWorld.z);
        }

        public void Rotate(Vector2 delta)
        {
            transform.Rotate(0, delta.x, 0);

            cameraRootAngle = Mathf.Clamp(cameraRootAngle - delta.y, -90, 90);
            cameraRoot.transform.localEulerAngles = new Vector3(cameraRootAngle, 0, 0);
        }
    }
}