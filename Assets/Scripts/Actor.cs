using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Actor : MonoBehaviour
    {
        [Tooltip("Represents the affiliation (or team) of the actor. Actors of the same affiliation are friendly to eachother")]
        public int Affiliation;
    }
}
