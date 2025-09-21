using Shooter.Items.Core.Weapons.ShootWeapons;
using UnityEngine;

namespace Shooter.Items.Features.Pistol
{
    public class PistolController : ShootWeaponController<PistolModel, PistolView>
    {
        protected override Vector3 GetShootDirection() => mainCamera.transform.forward;
    }
}