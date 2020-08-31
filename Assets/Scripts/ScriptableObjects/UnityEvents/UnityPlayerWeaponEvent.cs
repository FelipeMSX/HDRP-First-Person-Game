using Assets.Scripts.Weapons;
using UnityEngine.Events;

namespace Assets.Scripts.ScriptableObjects.UnityEvents
{
    [System.Serializable] public class UnityPlayerWeaponEvent : UnityEvent<Weapon> { }
}
