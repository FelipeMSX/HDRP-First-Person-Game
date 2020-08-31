using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public abstract class EnemyWeaponShootable : EnemyWeapon
    {
        public IBehaviourShootable BehaviourShoot;

        public GameObject ProjectilePrefab;

        public Transform ShootPosition;

        [Tooltip("Sound played on pickup")]
        public AudioSource ShootAudio;

        public ParticleSystem ProjectileEjectionEffect;

        public int MaxAmmo;

        public int CurrentAmmo;

        public int MaxClipSize;

        public float FireRate;

        public int CurrentClipSize;
    }
}
