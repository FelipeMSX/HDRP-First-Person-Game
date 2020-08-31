using Assets.Scripts.Weapons.Behaviours;

namespace Assets.Scripts.Enemy.Weapons
{
    public class Laser : EnemyWeaponShootable
    {
        public override void Fire()
        {
            BehaviourShoot.Shoot();
        }

        private void Start()
        {
            WeaponType = EnemyWeaponTypes.Laser;

            BehaviourShoot = GetComponent<IBehaviourShootable>();

        }

        private void Update()
        {
            Fire();   
        }
    }
}
