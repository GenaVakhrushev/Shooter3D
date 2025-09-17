using Shooter.Items.Core;
using Shooter.Items.Core.Weapons.ShootWeapons;
using UnityEngine;

namespace Shooter.Items.Features.Pistol
{
     [CreateAssetMenu(fileName = nameof(PistolConfig), menuName = "Configs/" + nameof(PistolConfig), order = 0)]
    public class PistolConfig : ShootWeaponConfig
    {
        public override ItemModel CreateModel() => new PistolModel { Name = ItemName, Damage = Damage };
    }
}