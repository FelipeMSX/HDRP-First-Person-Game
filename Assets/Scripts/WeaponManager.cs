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


        private WeaponTypes _previousWeapon;

        void Start()
        {    
            RefreshPlayerWeapon();
        }

        public void SwitchWeaponPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!this.isActiveAndEnabled || !CanSwitchCurrentWeapon())
                return;

            CurrentWeapon = (WeaponTypes)Convert.ToInt32(obj.control.displayName) - 1;

            RefreshPlayerWeapon();
        }

        private void RefreshPlayerWeapon()
        {
            if (_previousWeapon == CurrentWeapon)
                return;

            int i = 0;
            GameObject currentWeapon = null;
            foreach (Transform weapon in transform)
            {
                //Before change the current weapon certifies that should remain in hig sight mode.
                if ((WeaponTypes)i == _previousWeapon)
                {
                    Weapon prevousWeapon = weapon.gameObject.GetComponent<Weapon>();
                    if (prevousWeapon is WeaponShootable weaponShootable)
                    {
                        weaponShootable.SwitchToDesiredWeaponSight(Weapons.Behaviours.WeaponSight.Hip);
                    }
                }

                if ((WeaponTypes)i == CurrentWeapon)
                {
                    currentWeapon = weapon.gameObject;
                }
                weapon.gameObject.SetActive((WeaponTypes)i == CurrentWeapon);

                i++;
            }

            if(currentWeapon != null)
            {
                Weapon weapon = currentWeapon.GetComponent<Weapon>();
                if(weapon != null)
                {

                    OnWeaponSwitched.Raise(weapon);
                    weapon.SmoothTransitionBehaviour?.SmoothTransition();


                }
            }

            _previousWeapon = CurrentWeapon;
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

    }
}