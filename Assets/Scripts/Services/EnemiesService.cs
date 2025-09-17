using System;
using System.Collections.Generic;
using Shooter.Enemies.Core;
using UnityEngine.Pool;
using Zenject;

namespace Shooter.Services
{
    public class EnemiesService
    {
        [Inject] private DiContainer container;
        [Inject] private TickableManager tickableManager;
        
        private readonly HashSet<IEnemyController> activeControllers = new();
        private readonly Dictionary<Type, ObjectPool<IEnemyController>> pools = new();
        
        public IEnemyController GetController(Type controllerType) => GetOrCreateControllerPool(controllerType).Get();

        public void ReturnController(IEnemyController enemyController) => GetOrCreateControllerPool(enemyController.GetType()).Release(enemyController);
        
        private ObjectPool<IEnemyController> GetOrCreateControllerPool(Type controllerType)
        {
            if (pools.TryGetValue(controllerType, out var pool))
            {
                return pool;
            }
            
            pool = new ObjectPool<IEnemyController>(CreateController, ActionOnGetController, ActionOnReleaseController);
            pools.Add(controllerType, pool);

            return pool;
            
            IEnemyController CreateController()
            {
                var enemyController = (IEnemyController)container.Instantiate(controllerType);

                if (enemyController is ITickable tickable)
                {
                    tickableManager.Add(tickable);
                }
                
                return enemyController;
            }

            void ActionOnGetController(IEnemyController controller)
            {
                activeControllers.Add(controller);
            }
            
            void ActionOnReleaseController(IEnemyController controller)
            {
                activeControllers.Remove(controller);
                
                controller.SetView(null);
                controller.SetModel(null);
            }
        }
    }
}