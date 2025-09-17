using System;
using System.Collections.Generic;
using Shooter.Core;
using UnityEngine.Pool;
using Zenject;

namespace Shooter.Services
{
    public abstract class ControllersService<TController> where TController : class, IController
    {
        [Inject] private DiContainer container;
        [Inject] private TickableManager tickableManager;
        
        private readonly HashSet<TController> activeControllers = new();
        private readonly Dictionary<Type, ObjectPool<TController>> pools = new();
        
        public TController GetController(Type controllerType) => GetOrCreateControllerPool(controllerType).Get();

        public void ReturnController(TController controller) => GetOrCreateControllerPool(controller.GetType()).Release(controller);
        
        private ObjectPool<TController> GetOrCreateControllerPool(Type controllerType)
        {
            if (pools.TryGetValue(controllerType, out var pool))
            {
                return pool;
            }
            
            pool = new ObjectPool<TController>(CreateController, ActionOnGetController, ActionOnReleaseController);
            pools.Add(controllerType, pool);

            return pool;
            
            TController CreateController()
            {
                var controller = (TController)container.Instantiate(controllerType);

                if (controller is ITickable tickable)
                {
                    tickableManager.Add(tickable);
                }
                
                return controller;
            }

            void ActionOnGetController(TController controller)
            {
                activeControllers.Add(controller);
            }
            
            void ActionOnReleaseController(TController controller)
            {
                activeControllers.Remove(controller);
                
                controller.SetView(null);
                controller.SetModel(null);
            }
        }
    }
}