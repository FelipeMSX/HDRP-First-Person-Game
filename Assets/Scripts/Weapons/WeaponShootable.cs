using Assets.Scripts.ScriptableObjects.Events;
using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Weapons
{
    public abstract class WeaponShootable : Weapon
    {
        [SerializeField]
        private IBehaviourReloadable _behaviourReload;
        public IBehaviourReloadable BehaviourReload 
        {
            get => _behaviourReload;
            set => _behaviourReload = value;
        }

        [SerializeField]
        private IBehaviourShootable _behaviourShoot;
        public IBehaviourShootable BehaviourShoot
        {
            get => _behaviourShoot;
            set => _behaviourShoot = value;
        }

        public IWeaponSwitchSightBehaviour WeaponSwitchSightBehaviour;

        [SerializeField]
        public VoidEvent OnWeaponEyeSightActived = null;

        [SerializeField]
        public VoidEvent OnWeaponHipSightActived = null;


        [SerializeField]
        private GameObject _projectilePrefab;
        public GameObject ProjectilePrefab
        {
            get => _projectilePrefab;
            set => _projectilePrefab = value;
        }

        [SerializeField]
        private Transform _shootPosition;
        public Transform ShootPosition
        {
            get => _shootPosition;
            set => _shootPosition = value;
        }

        [Tooltip("Sound played on pickup"), SerializeField]
        private AudioSource _shootAudio;
        public AudioSource ShootAudio
        {
            get => _shootAudio;
            set => _shootAudio = value;
        }

        [SerializeField]
        private ParticleSystem _muzzleFlashEffect;
        public ParticleSystem MuzzleFlashEffect
        {
            get => _muzzleFlashEffect;
            set => _muzzleFlashEffect = value;
        }

        [SerializeField]
        private ParticleSystem _projectileEjectionEffect;
        public ParticleSystem ProjectileEjectionEffect
        {
            get => _projectileEjectionEffect;
            set => _projectileEjectionEffect = value;
        }


        [SerializeField]
        private int _maxAmmo;
        public int MaxAmmo
        {
            get => _maxAmmo;
            set => _maxAmmo = value;
        }

        [SerializeField]
        private int _currentAmmo;
        public int CurrentAmmo
        {
            get => _currentAmmo;
            set => _currentAmmo = value;
        }

        [SerializeField]
        private int _MaxClipSize;
        public int MaxClipSize
        {
            get => _MaxClipSize;
            set => _MaxClipSize = value;
        }

        [SerializeField]
        private float _fireRate;
        public float FireRate
        {
            get => _fireRate;
            set => _fireRate = value;
        }

        [SerializeField]
        private int _currentClipSize;
        public int CurrentClipSize
        {
            get => _currentClipSize;
            set => _currentClipSize = value;
        }


        public abstract void Reload();
    }
}
