using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public interface ISmoothWeaponTransitionBehaviour
    {

        float Speed { get; set; }

        /// <summary>
        /// Indicates that behaviour is executing.
        /// </summary>
        bool IsInAction { get; }

        /// <summary>
        /// The initial position to move the object until the final position.
        /// </summary>
        Vector3 InitialPosition { get; set; }

        /// <summary>
        /// Indicates the position that the object should stay.
        /// </summary>
        Vector3 FinalPosition { get; set; }


        /// <summary>
        /// Begins the process of moving the object from starting position to the ending position.
        /// </summary>
        void SmoothTransition();
    }
}
