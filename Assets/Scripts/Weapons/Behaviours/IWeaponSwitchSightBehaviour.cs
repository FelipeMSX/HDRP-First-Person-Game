namespace Assets.Scripts.Weapons.Behaviours
{
    public interface IWeaponSwitchSightBehaviour
    {
        /// <summary>
        ///Indicates that the object is moving between the options.
        /// </summary>
        bool IsInAction { get; }

        /// <summary>
        /// Moves the object to the eye sight that is right in the front of the camera.
        /// </summary>
        void MoveToEyeSight();

        /// <summary>
        /// Moves the object to the hipt sight that is slightly far from the camera.
        /// </summary>
        void RestoreSight();

        /// <summary>
        /// Indicates the current state of weapon sight.
        /// </summary>
        WeaponSight CurrentWeaponSight { get; }
    }
    public enum WeaponSight { Eye, Hip }

}
