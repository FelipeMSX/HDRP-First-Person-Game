using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Weapons
{
    public class ProjectileStandard : MonoBehaviour, IProjectile
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

        /// <summary>
        /// Intercepts the destruction of the bullet and transfer the responsibility to another layer.
        /// </summary>
        public UnityAction<ProjectileStandard> OnBulletDestructionIntercepted;

        //Refatorar
        public Vector3 Direction;
        private RangeDestructionBehaviour _behaviourRangeDestruction;
        public WeaponShootable Weapon;

        private bool _stop;


        private void Start()
        {
            _behaviourRangeDestruction = GetComponent<RangeDestructionBehaviour>();
            _behaviourRangeDestruction.AddItemToDestruction(this);
            //The Bullet is disabled initially.
            _stop = false;
        }

        private void FixedUpdate()
        {
            if (_stop)
                return;

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
                _stop = true;
                DisableRecycleRoutine();
            }
        }


        private BehaviourSurfaceHit GetBehaviourSurfaceHit(GameObject gameObject)
        {
            BehaviourSurfaceHit found;
            BehaviourSurfaceHit behaviourSurfaceHit = gameObject.GetComponent<BehaviourSurfaceHit>();

            found = behaviourSurfaceHit != null ? behaviourSurfaceHit : gameObject.GetComponentInParent<BehaviourSurfaceHit>() ;

            return found;
        }

        public void EnableRecyleRoutine(Vector3 direction, WeaponShootable weaponShootable)
        {
             Direction = direction;
            Weapon = weaponShootable;
            transform.position = weaponShootable.ShootPosition.position;
            transform.rotation = Quaternion.LookRotation(direction);

            if(_behaviourRangeDestruction != null)
            _behaviourRangeDestruction.AddItemToDestruction(this);

            if (!this.isActiveAndEnabled)
                gameObject.SetActive(true);

            _stop = false;
        }

        public void DisableRecycleRoutine()
        {
            gameObject.SetActive(false);
            //Resets the bullet position.
            transform.position = Weapon.ShootPosition.position;
            Weapon.RecycleProjectileWrapper.AddOrDestroyObject(gameObject);
        }


    }
}
