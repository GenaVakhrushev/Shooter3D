using Shooter.Core;
using Shooter.HP;

namespace Shooter.Enemies.Core
{
    public class EnemyController<TEnemyModel, TEnemyView> : Controller<TEnemyModel, TEnemyView>, IEnemyController
        where TEnemyModel : EnemyModel
        where TEnemyView : EnemyView
    {
        private readonly HPController hpController = new();
        
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
                return;
            }
            
            View.DamageTaken += ViewOnDamageTaken;
            hpController.SetView(View.GetComponentInChildren<HPView>());
        }

        protected override void OnModelChanged()
        {
            hpController.SetModel(Model.HPModel);
        }

        private void ViewOnDamageTaken(float damage)
        {
            hpController.RemoveHP(damage);
        }
    }
}