using Assets.Scripts.ScriptableObjects.Events;
using Assets.Scripts.Weapons;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponManager : MonoBehaviour
    {
        public WeaponTypes CurrentWeapon;

        [SerializeField]
        private PlayerWeaponGameEvent OnWeaponSwitched = null;


        private Weapon _currentWeapon;
        private Weapon _nextWeapon;

        void Start()
        {
            _currentWeapon = GetWeaponByType(CurrentWeapon);
            RefreshPlayerWeapon();
        }

        public void SwitchWeaponPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled || !CanSwitchCurrentWeapon())
                return;

            _nextWeapon = GetWeaponByType((WeaponTypes)Convert.ToInt32(obj.control.displayName) - 1);

            RefreshPlayerWeapon();
        }

        private void RefreshPlayerWeapon()
        {
            if (_currentWeapon == _nextWeapon || _nextWeapon == null)
                return;

            //Checks the currentWeaponTypes before switch to next weapon
            if (_currentWeapon is WeaponShootable weaponShootable)
            {
                if (weaponShootable.IsShooting)
                {
                    //Cannot continue the weapon is currently firing.
                    return;
                }
                weaponShootable.SwitchToDesiredWeaponSight(Weapons.Behaviours.WeaponSight.Hip);
            }

            _currentWeapon.gameObject.SetActive(false);
            _nextWeapon.gameObject.SetActive(true);
            OnWeaponSwitched.Raise(_nextWeapon);
            _nextWeapon.SmoothTransitionBehaviour?.SmoothTransition();
            CurrentWeapon   = _nextWeapon.WeaponType;
            _currentWeapon  = _nextWeapon;
        }


        //Switchs the current weapon only if is not busy "action".
        private bool CanSwitchCurrentWeapon()
        {
            foreach (Transform item in transform)
            {
                Weapon weapon =  item.gameObject.GetComponent<Weapon>();
                if(weapon != null && weapon.WeaponType == CurrentWeapon && !weapon.IsInAction)
                    return !weapon.IsInAction;
            }

            return false;
        }


        private Weapon GetWeaponByType(WeaponTypes weaponTypes)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform weaponTransform = transform.GetChild(i);
                Weapon weapon = weaponTransform.gameObject.GetComponent<Weapon>();

                if (weapon.WeaponType == weaponTypes)
                    return weapon;
            }

            return null;
        }

    }
}