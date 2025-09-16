using System;
using Shooter.Items.Core.Weapons.ShootWeapons;

namespace Shooter.Items.Features.Pistol
{
    public class PistolModel : ShootWeaponModel
    {
        public override object Clone() => new PistolModel() { Name = Name, Damage = Damage, HitDistance = HitDistance };

        public override Type GetControllerType() => typeof(PistolController);
    }
}