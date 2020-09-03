using Assets.Scripts.Weapons.Behaviours;

namespace Assets.Scripts.Weapons
{
    public class Pistol : WeaponShootable
    {
        public override bool IsShooting { get; set; }

        public override RecycleProjectileWrapper RecycleProjectileWrapper { get; set; }

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
            WeaponType = WeaponTypes.Pistol;

            BehaviourReload = GetComponent<IBehaviourReloadable>();
            BehaviourShoot = GetComponent<IBehaviourShootable>();
            WeaponSwitchSightBehaviour = GetComponent<IWeaponSwitchSightBehaviour>();
            RecoilBehaviour = GetComponent<IRecoilBehaviour>();
            SmoothTransitionBehaviour = GetComponent<ISmoothWeaponTransitionBehaviour>();
            RecycleProjectileWrapper = GetComponent<RecycleProjectileWrapper>();
        }

        private void Update()
        {
   
        }

        public void ShootPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled)
                return;

            if (!WeaponSwitchSightBehaviour.IsInAction)
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
