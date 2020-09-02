using Assets.Scripts.Weapons.Behaviours;

namespace Assets.Scripts.Weapons
{
    public class AssaultRifleHK416 : WeaponShootable
    {

        //Maybe this is not a property.
        public override bool IsShooting { get; set; }


        public override void Reload()
        {
            BehaviourReload.Reload();
        }

        public override void Fire()
        {
            if (BehaviourShoot == null)
                return;

            if (BehaviourShoot.CanShoot())
            {
                BehaviourShoot.Shoot();

                if (RecoilBehaviour != null)
                    RecoilBehaviour.AddRecoilForce();
            }
        }


        private void Start()
        {
            WeaponType = WeaponTypes.AssaultRifleHK416;

            BehaviourReload = GetComponent<IBehaviourReloadable>();
            BehaviourShoot = GetComponent<IBehaviourShootable>();
            WeaponSwitchSightBehaviour = GetComponent<IWeaponSwitchSightBehaviour>();
            RecoilBehaviour = GetComponent<IRecoilBehaviour>();
            SmoothTransitionBehaviour = GetComponent<ISmoothWeaponTransitionBehaviour>();



        }

        private void Update()
        {
            if (IsShooting && !WeaponSwitchSightBehaviour.IsInAction)
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
