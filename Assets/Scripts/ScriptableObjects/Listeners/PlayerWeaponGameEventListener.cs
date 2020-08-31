using Assets.Scripts.ScriptableObjects.Events;
using Assets.Scripts.ScriptableObjects.UnityEvents;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.ScriptableObjects.Listeners
{
    public class PlayerWeaponGameEventListener : BaseGameEventListener<Weapon, PlayerWeaponGameEvent, UnityPlayerWeaponEvent>
    {
    }
}
