using UnityEngine;

namespace Assets.Scripts
{
    public class WallClockBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 1.5f;

        public float RotationSpeed
        {
            get => _rotationSpeed;
            set => _rotationSpeed = value;
        }

        [SerializeField]
        private Transform _secondPointer;
        public Transform SecondPointer
        {
            get => _secondPointer;
            set => _secondPointer = value;
        }

        private void Update()
        {
            _secondPointer.Rotate(0f, 0f, _secondPointer.rotation.z + _rotationSpeed + Time.deltaTime, Space.Self);
        }

    }
}
