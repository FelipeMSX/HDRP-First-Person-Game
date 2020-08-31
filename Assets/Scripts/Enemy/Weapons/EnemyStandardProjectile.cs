using Assets.Scripts.Enemy.Weapons.Behaviours;
using Assets.Scripts.Weapons;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public class EnemyStandardProjectile : MonoBehaviour
    {

        public float BulletSpeed = 100f;
        public float ImpactForce = 200f;
        public float Range = 100f;

        //Refatorar isso aqui
        public Vector3 Direction;
        public EnemyWeaponShootable Weapon;


        private EnemyRangeDestructionBehaviour _behaviourEnemyRangeDestruction;

        private void Start()
        {
            _behaviourEnemyRangeDestruction = GetComponent<EnemyRangeDestructionBehaviour>();
            _behaviourEnemyRangeDestruction.AddItemToDestruction(this);
        }

        private void FixedUpdate()
        {
            bool hitted = Physics.Raycast(transform.position, Direction, out RaycastHit rayCastHit, 3f);

            if (hitted)
            {
                hitted = true;
                BehaviourSurfaceHit behaviourSurfaceHit = GetBehaviourSurfaceHit(rayCastHit.transform.gameObject);

                if (behaviourSurfaceHit)
                {
                    behaviourSurfaceHit.ShowDecal(rayCastHit.point, rayCastHit.normal);
                    behaviourSurfaceHit.ShowHitEffect(rayCastHit.point, rayCastHit.normal);
                }

                if (rayCastHit.rigidbody != null)
                {
                    rayCastHit.rigidbody.AddForce(-rayCastHit.normal * ImpactForce, ForceMode.Force);
                }
                Health health = rayCastHit.transform.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(Weapon.Damage, this.gameObject);
                }

            }

            if (!hitted)
            {
                transform.position += transform.forward * BulletSpeed * Time.fixedDeltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        private BehaviourSurfaceHit GetBehaviourSurfaceHit(GameObject gameObject)
        {
            BehaviourSurfaceHit found;
            BehaviourSurfaceHit behaviourSurfaceHit = gameObject.GetComponent<BehaviourSurfaceHit>();

            found = behaviourSurfaceHit != null ? behaviourSurfaceHit : gameObject.GetComponentInParent<BehaviourSurfaceHit>();

            return found;
        }
    }
}
