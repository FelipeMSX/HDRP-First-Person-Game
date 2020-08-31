using Assets.Scripts.ScriptableObjects.Events;
using Assets.Scripts.ScriptableObjects.UnityEvents;

namespace Assets.Scripts.ScriptableObjects.Listeners
{
    public class PlayerHealthEventListener : BaseGameEventListener<Health, PlayerHealthGameEvent, UnityPlayerHealthEvent>
    {
    }
}
