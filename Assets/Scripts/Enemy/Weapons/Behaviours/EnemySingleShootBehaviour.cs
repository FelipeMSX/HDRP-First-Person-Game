using Assets.Scripts.Helpers;
using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons.Behaviours
{
    public class EnemySingleShootBehaviour : MonoBehaviour, IBehaviourShootable
    {
        public GameObject Target;
        private EnemyWeaponShootable _weapon;
        private float _nextTimetoFire = 0f;


        private void Update()
        {
            if (_nextTimetoFire <= 1f)
                _nextTimetoFire += ((_weapon.FireRate / 10f) * Time.deltaTime);
        }

        private void Start()
        {
            _weapon = GetComponent<EnemyWeaponShootable>();
        }

        public void Shoot()
        {
            if (!CanShoot())
                return;

            _weapon.CurrentClipSize--;
            _nextTimetoFire = 0f;
            Vector3 dir = Target.transform.position - transform.position;


            GameObject clone = Instantiate(_weapon.ProjectilePrefab, _weapon.ShootPosition.position, Quaternion.LookRotation(dir));
            EnemyStandardProjectile bullet = clone.GetComponent<EnemyStandardProjectile>();
            bullet.Direction = dir;
            bullet.Weapon = _weapon;
        }

        public bool CanShoot() => WeaponHelper.CanShoot(_weapon.CurrentClipSize, _nextTimetoFire);
        
    }
}
