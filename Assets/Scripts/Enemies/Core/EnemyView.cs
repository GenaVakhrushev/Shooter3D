using System;
using Shooter.Core;
using Shooter.Damage;
using Shooter.Factories;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Shooter.Enemies.Core
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class EnemyView : View, IDamageable
    {
        [Inject] private EnemiesFactory enemiesFactory;
        
        public string EnemyName { get; private set; }
        
        private NavMeshAgent agent;
        private Transform targetTransform;
        private float lastPathCalculateTime;

        private const float PATH_CALCULATE_DELAY = 0.1f;
        private const float DISTANCE_DELTA = 0.1f;

        public event Action<float> DamageTaken;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (targetTransform != null 
                && lastPathCalculateTime + PATH_CALCULATE_DELAY >= Time.time 
                && Vector3.Distance(agent.destination, targetTransform.position) >= DISTANCE_DELTA)
            {
                lastPathCalculateTime = Time.time;

                agent.SetDestination(targetTransform.position);
            }
        }

        public void TakeDamage(float damage)
        {
            DamageTaken?.Invoke(damage);
        }

        public void UpdateToModel(EnemyModel enemyModel)
        {
            agent.speed = enemyModel.MoveSpeed;
            agent.angularSpeed = enemyModel.RotationSpeed;
        }

        public void SetTarget(Transform target)
        {
            targetTransform = target;
        }

        public void SetDestination(Vector3 destination)
        {
            targetTransform = null;
            agent.SetDestination(destination);
        }

        public void SetStoppingDistance(float stoppingDistance)
        {
            agent.stoppingDistance = stoppingDistance;
        }

        public void SetEnemyName(string enemyName)
        {
            EnemyName = enemyName;
        }

        public void Die()
        {
            enemiesFactory.ReturnView(this);
        }
    }
}