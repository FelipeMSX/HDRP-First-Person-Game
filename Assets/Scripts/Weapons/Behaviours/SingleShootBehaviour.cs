using Assets.Scripts.Helpers;
using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class SingleShootBehaviour : MonoBehaviour, IBehaviourShootable
    {

        [SerializeField]
        private PlayerWeaponGameEvent OnWeaponFired;

        private WeaponShootable _weapon;

        private float _nextTimetoFire = 0f;

        private Animation _animation;

        private Transform _cameraTransform;
        private void Start()
        {
            _weapon = GetComponent<WeaponShootable>();
            _animation = _weapon.GetComponent<Animation>();
            _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            if(_nextTimetoFire <= 1f)
                _nextTimetoFire += ((_weapon.FireRate/10f) * Time.deltaTime ) ;
        }

        public void Shoot()
        {
            if (!WeaponHelper.CanShoot(_weapon.CurrentClipSize, _nextTimetoFire))
                return;

            _weapon.CurrentClipSize--;
            _nextTimetoFire = 0f;


            Vector3 targetDirection;

            bool result = Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit);

            targetDirection = result ? hit.point - _weapon.ShootPosition.position : _cameraTransform.forward;

            GameObject clone = Instantiate(_weapon.ProjectilePrefab, _weapon.ShootPosition.position, Quaternion.LookRotation(targetDirection));
            ProjectileStandard bullet = clone.GetComponent<ProjectileStandard>();
            bullet.Direction = targetDirection;
            bullet.Weapon = _weapon;

            _weapon.ShootAudio.PlayOneShot(_weapon.ShootAudio.clip);
            _weapon.MuzzleFlashEffect.Play();

            if(_weapon.ProjectileEjectionEffect != null)
                _weapon.ProjectileEjectionEffect.Play();

            if(_animation != null)
            {
                _animation.AddClip(_weapon.ActionAnimation, "Shoot");
                _animation.Play("Shoot");
            }

            OnWeaponFired?.Raise(_weapon);



        }

        public bool CanShoot()
        {
            return WeaponHelper.CanShoot(_weapon.CurrentClipSize, _nextTimetoFire);
        }
    }
}
