namespace Shooter.Damage
{
    public class DamageCalculator
    {
        public float CalculateDamage(object damager, IDamageSource source, IDamageable damageable)
        {
            if (CanDealDamage(damager, damageable))
            {
                var damage = source.GetDamage();

                if (damager is IDamageModifierHolder damageModifierHolder)
                {
                    damage = damageModifierHolder.ModifyDamage(damage);
                }
                
                return damage;
            }

            return 0;
        }

        private bool CanDealDamage(object damager, IDamageable damageable)
        {
            return true;
        }
    }
}