using Shooter.Core;
using Shooter.Damage;
using Shooter.Items.Core;
using UnityEngine;
using Zenject;

namespace Shooter.Items.Features.Pistol
{
    public class PistolController : Controller<PistolModel, PistolView>, IItemController, IDamageDealer
    {
        [Inject] private DamageCalculator damageCalculator;
        
        private readonly Camera mainCamera = Camera.main;

        public void StartUseItem()
        {
            var mainCameraTransform = mainCamera.transform;
            var ray = new Ray(mainCameraTransform.position, mainCameraTransform.forward);
            
            if (Physics.Raycast(ray, out var hit) && hit.transform.TryGetComponent(out IDamageable damageable))
            {
                var damage = damageCalculator.CalculateDamage(this, damageable);

                if (damage > 0)
                {
                    damageable.TakeDamage(damage);
                }
            }
        }

        public void StopUseItem()
        {
            
        }

        public float GetDamage() => Model.Damage;
    }
}