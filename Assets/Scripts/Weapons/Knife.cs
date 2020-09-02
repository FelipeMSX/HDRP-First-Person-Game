using Assets.Scripts.Weapons.Behaviours;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Knife : WeaponMelee
    {


        private void Start()
        {
            SmoothTransitionBehaviour = GetComponent<ISmoothWeaponTransitionBehaviour>();
        }
 

        public override void Fire()
        {
            throw new System.NotImplementedException();
        }
    }
}
