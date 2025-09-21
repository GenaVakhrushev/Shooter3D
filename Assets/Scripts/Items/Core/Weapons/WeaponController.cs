namespace Shooter.Items.Core.Weapons
{
    public abstract class WeaponController<TWeaponModel, TWeaponView> : ItemController<TWeaponModel, TWeaponView>
        where TWeaponModel : WeaponModel
        where TWeaponView : WeaponView
    {
        
    }
}