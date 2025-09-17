using System;
using UnityEngine;

namespace Shooter.Utils
{
    public class LookAtMainCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationOffset;
        
        private Camera mainCamera;

        private Camera MainCamera
        {
            get
            {
                if (mainCamera == null)
                {
                    mainCamera = Camera.main;
                }

                return mainCamera;
            }
        }

        private void LateUpdate()
        {
            var cameraPosition = MainCamera.transform.position;
            var lookRotation = Quaternion.LookRotation(cameraPosition - transform.position, Vector3.up);
            
            transform.rotation = lookRotation * Quaternion.Euler(rotationOffset);
        }
    }
}