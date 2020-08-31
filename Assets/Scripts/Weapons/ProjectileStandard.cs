using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Weapons
{
    public class ProjectileStandard : MonoBehaviour
    {

        [SerializeField]
        private float _bulletSpeed = 100f;
        public float BulletSpeed
        {
            get => _bulletSpeed;
            set => _bulletSpeed = value;
        }

        [SerializeField]
        private float _impactForce = 200f;
        public float ImpactForce
        {
            get => _impactForce;
            set => _impactForce = value;
        }

        [SerializeField]
        private float _range = 100;
        public float Range
        {
            get => _range;
            set => _range = value;
        }

        public UnityAction<ProjectileStandard, GameObject> OnBulletCollided;


        //Refatorar
        public Vector3 Direction;
        private RangeDestructionBehaviour _behaviourRangeDestruction;
        public WeaponShootable Weapon;


        private void Start()
        {
            _behaviourRangeDestruction = GetComponent<RangeDestructionBehaviour>();
            _behaviourRangeDestruction.AddItemToDestruction(this);
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

                if(rayCastHit.rigidbody != null)
                {
                    rayCastHit.rigidbody.AddForce(-rayCastHit.normal * ImpactForce, ForceMode.Force);
                }

                Health health = rayCastHit.transform.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(Weapon.Damage, Weapon.gameObject);
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

            found = behaviourSurfaceHit != null ? behaviourSurfaceHit : gameObject.GetComponentInParent<BehaviourSurfaceHit>() ;

            return found;
        }
    }
}
