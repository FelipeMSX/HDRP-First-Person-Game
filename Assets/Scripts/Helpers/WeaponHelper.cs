namespace Assets.Scripts.Helpers
{
    public static class WeaponHelper
    {
        public static bool CanShoot(int currentClipSize, float nextTimetoFire) 
            => currentClipSize > 0 && nextTimetoFire >= 1.0f;

    }
}
