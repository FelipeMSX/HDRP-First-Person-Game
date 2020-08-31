using Assets.Scripts.Weapons.Behaviours;

namespace Assets.Scripts.Weapons
{
    public class Pistol : WeaponShootable
    {
        public bool IsShooting { get; private set; }


        public override void Reload()
        {
            BehaviourReload.Reload();
        }

        public override void Fire()
        {
            BehaviourShoot.Shoot();
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
            WeaponType = WeaponTypes.Pistol;

            BehaviourReload = GetComponent<IBehaviourReloadable>();
            BehaviourShoot = GetComponent<IBehaviourShootable>();
            WeaponSwitchSightBehaviour = GetComponent<IWeaponSwitchSightBehaviour>();

        }

        private void Update()
        {
   
        }

        public void ShootPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled)
                return;

            if (!WeaponSwitchSightBehaviour.IsMoving)
            {
                IsShooting = true;
                Fire();
            }
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
