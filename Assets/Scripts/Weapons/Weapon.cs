using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {

        public float Damage;
        public bool IsInAction;
        public AnimationClip ActionAnimation;
        public WeaponTypes WeaponType;

        public ISmoothWeaponTransitionBehaviour SmoothTransitionBehaviour { get; set; }

        public abstract void Fire();


    }

    public enum WeaponTypes : byte { Knife, Pistol, AssaultRifleHK416 };

}
