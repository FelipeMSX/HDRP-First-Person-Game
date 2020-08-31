using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class WeaponSwitchSightBehaviour : MonoBehaviour, IWeaponSwitchSightBehaviour
    {
        public float LocationSpeed = 3.5f;
        public float RotationSpeed = 9f;

        public Vector3 EyeSigthPosition;
        public Vector3 EyeSightRotation;

        public bool IsMoving { get; private set; }


        private Vector3 _originalRotation;
        private Vector3 _originalPosition;
        private Vector3 _previousPosition;
        private Vector3 _previousRotation;



        public WeaponSight CurrentWeaponSight { get; private set; }

        private void Start()
        {
            _originalPosition = transform.localPosition;
            _originalRotation = transform.localRotation.eulerAngles;
            CurrentWeaponSight = WeaponSight.Hip;
        }


        public void Update()
        {
            if (!IsMoving)
                return;

            if (CurrentWeaponSight == WeaponSight.Eye)
            {
                transform.localPosition = Vector3.MoveTowards(_previousPosition, EyeSigthPosition, LocationSpeed * Time.deltaTime);
                _previousPosition = transform.localPosition;

                transform.localRotation = Quaternion.RotateTowards(Quaternion.Euler(_previousRotation.x, _previousRotation.y, _previousRotation.z),
                    Quaternion.Euler(EyeSightRotation.x, EyeSightRotation.y, EyeSightRotation.z), RotationSpeed * Time.deltaTime);
                _previousRotation = transform.localRotation.eulerAngles;

                if (_previousPosition == EyeSigthPosition)
                {
                    IsMoving = false;
                }

            }
            else if (CurrentWeaponSight == WeaponSight.Hip)
            {

                gameObject.transform.localPosition = Vector3.MoveTowards(_previousPosition, _originalPosition, LocationSpeed * Time.deltaTime);
                _previousPosition = this.transform.localPosition;

                this.transform.localRotation = Quaternion.RotateTowards(Quaternion.Euler(_previousRotation.x, _previousRotation.y, _previousRotation.z),
                    Quaternion.Euler(_originalRotation.x, _originalRotation.y, _originalRotation.z), RotationSpeed * Time.deltaTime);
                _previousRotation = this.transform.localRotation.eulerAngles;

                if (_previousPosition == _originalPosition)
                {
                    IsMoving = false;
                }
            }


            //Olhar problemas com a rotação ainda.
        }


        public void MoveToEyeSight()
        {
            CurrentWeaponSight = WeaponSight.Eye;
            _previousPosition = transform.localPosition;
            _previousRotation = transform.localRotation.eulerAngles;
            IsMoving = true;
        }

        public void RestoreSight()
        {
            CurrentWeaponSight = WeaponSight.Hip;
            _previousPosition = EyeSigthPosition;
            _previousRotation = EyeSightRotation;
            IsMoving = true;
        }
    }

}
