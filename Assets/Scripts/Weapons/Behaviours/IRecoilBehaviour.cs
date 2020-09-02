using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public interface IRecoilBehaviour
    {

        ///// <summary>
        ///// The initial position to move the object until the final position.
        ///// </summary>
        //Vector3 InitialPosition { get; set; }

        ///// <summary>
        ///// Indicates the position that the object should stay.
        ///// </summary>
        //Vector3 FinalPosition { get; set; }

        /// <summary>
        /// Began the process of moving the object from starting position to the ending position.
        /// </summary>
        void AddRecoilForce();
    }
}
