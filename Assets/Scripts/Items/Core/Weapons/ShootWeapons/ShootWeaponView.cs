using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Shooter.Items.Core.Weapons.ShootWeapons
{
    public class ShootWeaponView : WeaponView
    {
        [SerializeField] private Transform shootStartPoint;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private TrailRenderer trailPrefab;
        [SerializeField, Min(0.01f)] private float trailLifetime;

        private ObjectPool<TrailRenderer> trails;

        private void Awake()
        {
            trails = new ObjectPool<TrailRenderer>(CreateFunc);
        }

        private void OnDestroy()
        {
            for (var i = 0; i < trails.CountAll; i++)
            {
                var trailRenderer = trails.Get();
                
                if (trailRenderer)
                {
                    Destroy(trailRenderer.gameObject);
                }
            }
        }

        public void Shoot(Vector3 hitPoint)
        {
            if (muzzleFlash)
            {
                muzzleFlash.Play();
            }

            if (trailPrefab)
            {
                StartCoroutine(LaunchTrail(hitPoint));
            }
        }

        private IEnumerator LaunchTrail(Vector3 hitPoint)
        {
            var trail = trails.Get();

            var trailTransform = trail.transform;
            
            trail.gameObject.SetActive(true);
            trail.time = trailLifetime;
            trailTransform.position = shootStartPoint.position;

            yield return null;

            trailTransform.position = hitPoint;

            yield return new WaitForSeconds(trailLifetime);

            trail.gameObject.SetActive(false);
            trails.Release(trail);
        }

        private TrailRenderer CreateFunc() => Instantiate(trailPrefab);
    }
}