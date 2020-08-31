using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class ReloadBehaviour : MonoBehaviour, IBehaviourReloadable
    {


        [SerializeField]
        private PlayerWeaponGameEvent OnWeaponReloaded;

        private WeaponShootable _weapon;
        private void Start()
        {
            _weapon = GetComponent<WeaponShootable>();
        }


        public void Reload()
        {
            if (!HasBullets())
                return;

            int reamingAmmo = _weapon.CurrentAmmo + _weapon.CurrentClipSize;

            if (reamingAmmo < _weapon.MaxClipSize)
            {
                _weapon.CurrentClipSize = reamingAmmo;
                _weapon.CurrentAmmo = 0;
            }
            else
            {
                _weapon.CurrentClipSize = _weapon.MaxClipSize;
                _weapon.CurrentAmmo = reamingAmmo - _weapon.MaxClipSize;
            }
            OnWeaponReloaded?.Raise(_weapon);
        }

        private bool HasBullets()
        {
            return _weapon.CurrentAmmo != 0;
        }
    }
}