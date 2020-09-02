using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class SmoothWeaponTransitionBehaviour : MonoBehaviour , ISmoothWeaponTransitionBehaviour
    {

        [SerializeField]
        private Vector3 _initialPosition;
        public Vector3 InitialPosition 
        { 
            get => _initialPosition; 
            set => _initialPosition = value; 
        }

        [SerializeField]
        private Vector3 _finalPosition;
        public Vector3 FinalPosition 
        { 
            get => _finalPosition; 
            set => _finalPosition = value; 
        }

        [SerializeField]
        public float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed  = value;
        }

        public bool IsInAction { get; private set; }

        private Vector3 _previousPosition;

        private void Update()
        {
            if (!IsInAction)
                return;


            gameObject.transform.localPosition = Vector3.MoveTowards(_previousPosition, FinalPosition, Speed * Time.deltaTime);
            _previousPosition = this.transform.localPosition;

            if (_previousPosition == FinalPosition)
            {
                IsInAction = false;
            }
        }

        public void SmoothTransition()
        {
            IsInAction = true;

            gameObject.transform.localPosition = InitialPosition;
            _previousPosition = InitialPosition;
        }
    }
}
