using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New Weapon Event", menuName = "ScriptableObjects/New Weapon Event", order = 4)]
    public class PlayerWeaponGameEvent : BaseGameEvent<Weapon>
    {
    }
}
