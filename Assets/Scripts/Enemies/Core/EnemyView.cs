using System;
using System.Collections;
using Cysharp.Threading.Tasks;
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
        [SerializeField] private Animator animator;
        [SerializeField] private float deathHideDelay;
        
        [Inject] private EnemiesFactory enemiesFactory;

        private bool canTakeDamage;

        private NavMeshAgent agent;
        private Transform targetTransform;
        private float lastPathCalculateTime;

        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int IsAlive = Animator.StringToHash("IsAlive");
        private static readonly int Killed = Animator.StringToHash("Killed");

        private const float PATH_CALCULATE_DELAY = 0.1f;
        private const float DISTANCE_DELTA = 0.1f;

        public string EnemyName { get; private set; }
        
        public event Action<float> DamageTaken;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            animator.SetBool(IsAlive, true);
            canTakeDamage = true;
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

            animator.SetBool(IsMoving, agent.remainingDistance > agent.stoppingDistance);
        }

        public void TakeDamage(float damage)
        {
            if (!canTakeDamage)
            {
                return;
            }
            
            animator.SetTrigger(Hit);
            
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

        public async void Die()
        {
            canTakeDamage = false;
            
            animator.SetBool(IsAlive, false);
            animator.SetTrigger(Killed);

            await UniTask.Delay((int)(deathHideDelay * 1000));
            
            enemiesFactory.ReturnView(this);
        }
    }
}