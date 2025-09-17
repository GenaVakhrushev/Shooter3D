namespace Shooter.Damage
{
    public class DamageCalculator
    {
        public float CalculateDamage(IDamageDealer dealer, IDamageable damageable)
        {
            if (CanDealDamage(dealer, damageable))
            {
                return dealer.GetDamage();
            }

            return 0;
        }

        private bool CanDealDamage(IDamageDealer dealer, IDamageable damageable)
        {
            return true;
        }
    }
}