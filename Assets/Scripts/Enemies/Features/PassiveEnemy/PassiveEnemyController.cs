using Shooter.Enemies.Core;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Shooter.Enemies.Features.PassiveEnemy
{
    public class PassiveEnemyController : EnemyController<PassiveEnemyModel, PassiveEnemyView>, ITickable
    {
        private float lastPositionChangeTime;
        
        public void Tick()
        {
            if (Model == null || View == null)
            {
                return;
            }

            if (lastPositionChangeTime + Model.NextPositionDelay <= Time.time)
            {
                TryMove();
            }
        }

        private void TryMove()
        {
            const int maxSampleTries = 10;
            
            var unitCircle = Random.insideUnitCircle;
            var offset = new Vector3(unitCircle.x, 0, unitCircle.y) * Model.NextPositionRange;

            for (var i = 0; i < maxSampleTries; i++)
            {
                if (NavMesh.SamplePosition(View.transform.position + offset, out var hit, 2, NavMesh.AllAreas))
                {
                    View.SetDestination(hit.position);
                    
                    break;
                }
            }

            lastPositionChangeTime = Time.time;
        }
    }
}