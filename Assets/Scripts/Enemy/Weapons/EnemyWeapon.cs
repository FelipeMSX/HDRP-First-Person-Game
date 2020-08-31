using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    public abstract class EnemyWeapon : MonoBehaviour
    {
        public float Damage;
        public AnimationClip ActionAnimation;
        public EnemyWeaponTypes WeaponType;

        public abstract void Fire();


    }

    public enum EnemyWeaponTypes : byte { Laser };
}
