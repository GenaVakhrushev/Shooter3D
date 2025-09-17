using Shooter.Databases;
using Shooter.Enemies;
using Shooter.Enemies.Core;

namespace Shooter.Factories
{
    public class EnemiesFactory : ViewsFactory
    {
        public EnemiesFactory(EnemiesDatabase enemiesDatabase)
        {
            foreach (var enemyConfig in enemiesDatabase.Configs)
            {
                AddViewPrefab(enemyConfig.Name, enemyConfig.EnemyView);
            }
        }

        public EnemyView GetEnemyView(EnemyModel enemyModel)
        {
            var enemyView = (EnemyView)GetView(enemyModel.Name);
            
            enemyView.SetEnemyName(enemyModel.Name);

            return enemyView;
        }

        public void ReturnView(EnemyView enemyView) => ReturnView(enemyView.EnemyName, enemyView);
    }
}