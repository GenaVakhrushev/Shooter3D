using System;
using Shooter.Core;
using Shooter.HP;

namespace Shooter.Enemies.Core
{
    public class EnemyController<TEnemyModel, TEnemyView> : Controller<TEnemyModel, TEnemyView>, IEnemyController
        where TEnemyModel : EnemyModel
        where TEnemyView : EnemyView
    {
        private readonly HPController hpController = new();

        public event Action EnemyDied;

        public EnemyController()
        {
            hpController.LostHP += HpControllerOnLostHP;
        }

        private void HpControllerOnLostHP()
        {
            View.Die();
            
            EnemyDied?.Invoke();
        }

        protected override void OnBeforeViewChanged()
        {
            if (View == null)
            {
                return;
            }
            
            View.DamageTaken -= ViewOnDamageTaken;
        }

        protected override void OnViewChanged()
        {
            if (View == null)
            {
                hpController.SetView(null);
                
                return;
            }

            View.UpdateToModel(Model);
            View.DamageTaken += ViewOnDamageTaken;
            hpController.SetView(View.GetComponentInChildren<HPView>());
        }

        protected override void OnModelChanged()
        {
            hpController.SetModel(Model?.HPModel);
        }

        private void ViewOnDamageTaken(float damage)
        {
            hpController.RemoveHP(damage);
        }
    }
}