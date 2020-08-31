using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class WeaponSwayBehaviour : MonoBehaviour, IBehaviourWeaponSway
    {

        public float swayLimit = 0.1f;
        public float swayVelocity = 0.5f;
        public Player _player;

        private Weapon _weapon;

        private Vector3 _originalPosition;
        private Vector3 _maxLimit;
        private Vector3 _minLImit;
        private Vector3 _sum;
        private bool _disabledBehaviour;

        
        public void Sway()
        {
            if (transform.localPosition.x >= _maxLimit.x)
            {
                _sum = Vector3.left * swayVelocity;
            }
            else if (transform.localPosition.x <= _minLImit.x)
            {
                _sum = Vector3.right * swayVelocity;
            }

            transform.localPosition = transform.localPosition + _sum * Time.deltaTime;
        }


        private void Start()
        {
            _weapon = GetComponent<Weapon>();

            _originalPosition = _weapon.gameObject.transform.localPosition;
            _maxLimit = _originalPosition+ Vector3.right * swayLimit;
            _minLImit = _originalPosition + Vector3.left * swayLimit;
            _sum = Vector3.left * swayVelocity;
        }

        private void Update()
        {
            if (_disabledBehaviour)
                return;

            if (_player.IsMoving)
            {
                Sway();
            }
            else if(transform.localPosition.x != _originalPosition.x)
            {
               transform.localPosition = Vector3.Lerp(transform.localPosition, _originalPosition,0.5f);
            }
        }


        //Called in a Scriptable Object
        public void DisableBehaviour()
        {
            _disabledBehaviour = true;
        }

        //Called in a Scriptable Object
        public void ActiveBehaviour()
        {
            _disabledBehaviour = false;
        }
    }
}
