using Assets.Scripts.ScriptableObjects.Events;
using Assets.Scripts.Weapons.Behaviours;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class AssaultRifleHK416 : WeaponShootable
    {

        private BehaviourRecoil _behaviourRecoil;

        public bool IsShooting { get; private set; }


        public override void Reload()
        {
            BehaviourReload.Reload();
        }

        public override void Fire()
        {
            if (BehaviourShoot.CanShoot())
            {
                BehaviourShoot.Shoot();

                if (_behaviourRecoil != null)
                    _behaviourRecoil.AddRecoilForce(transform.localPosition);
            }
        }


        public void SwitchWeaponSight()
        {
            if (WeaponSwitchSightBehaviour.CurrentWeaponSight == WeaponSight.Hip)
            {
                WeaponSwitchSightBehaviour.MoveToEyeSight();
                OnWeaponEyeSightActived?.Raise();
            }
            else
            {
                WeaponSwitchSightBehaviour.RestoreSight();
                OnWeaponHipSightActived?.Raise();
            }
        }

        private void Start()
        {
            WeaponType = WeaponTypes.AssaultRifleHK416;

            BehaviourReload = GetComponent<IBehaviourReloadable>();
            BehaviourShoot = GetComponent<IBehaviourShootable>();
            WeaponSwitchSightBehaviour = GetComponent<IWeaponSwitchSightBehaviour>();
            _behaviourRecoil = GetComponent<BehaviourRecoil>();


        }

        private void Update()
        {
            if (IsShooting && !WeaponSwitchSightBehaviour.IsMoving)
            {
                Fire();
            }
        }

        public void ShootPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled)
                return;

            IsShooting = true;
        }

        public void ShootCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled)
                return;

            IsShooting = false;
        }

        public void ReloadPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled)
                return;

            Reload();
        }

        public void WeaponEyeSightPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled)
                return;

            if (CanMoveWeaponSight())
            {
                SwitchWeaponSight();
            }
        }


        private bool CanMoveWeaponSight() => !IsShooting;
    }
}
