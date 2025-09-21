using Shooter.Damage;
using UnityEngine;
using Zenject;

namespace Shooter.Items.Core.Weapons.ShootWeapons
{
    public abstract class ShootWeaponController<TShootWeaponModel, TShootWeaponView> : WeaponController<TShootWeaponModel, TShootWeaponView>, IDamageSource
        where TShootWeaponModel : ShootWeaponModel
        where TShootWeaponView : ShootWeaponView
    {
        [Inject] private DamageCalculator damageCalculator;

        private const float NO_HIT_SHOOT_POINT_DISTANCE = 1000;
        
        protected readonly Camera mainCamera = Camera.main;
        
        public override void StartUseItem(object user)
        {
            base.StartUseItem(user);
            
            var mainCameraTransform = mainCamera.transform;
            var ray = new Ray(mainCameraTransform.position, GetShootDirection());

            var hit = Physics.Raycast(ray, out var raycastHit);
            
            View.Shoot(hit ? raycastHit.point : ray.GetPoint(NO_HIT_SHOOT_POINT_DISTANCE));
            
            if (hit && raycastHit.transform.TryGetComponent(out IDamageable damageable))
            {
                var damage = damageCalculator.CalculateDamage(user, this, damageable);

                if (damage > 0)
                {
                    damageable.TakeDamage(damage);
                }
            }
        }

        protected abstract Vector3 GetShootDirection();

        public float GetDamage() => Model.Damage;
    }
}