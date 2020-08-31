using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class BehaviourRecoil : MonoBehaviour
    {
        public float RecoilForce = 5f;
        public float Speed = 3.5f;

        private bool _shooted = false;
        private bool _restore = false;

        private Vector3 _originalPosition;
        private Vector3 _recoilPosition;

        private Vector3 _previousPosition;


        private void Update()
        {
            if (_restore)
            {
                transform.localPosition = Vector3.MoveTowards(_previousPosition, _originalPosition, Speed * Time.deltaTime);
                _previousPosition = transform.localPosition;

                if (_previousPosition == _originalPosition)
                {
                    _restore = false;
                }
            }


            if (_previousPosition == _recoilPosition)
                return;

            if (_shooted)
            {
                transform.localPosition = Vector3.MoveTowards(_previousPosition, _recoilPosition, Speed * Time.deltaTime);
                _previousPosition = transform.localPosition;

                if (_previousPosition == _recoilPosition)
                {
                    _shooted = false;
                    _restore = true;
                }

            }

        }

        public void AddRecoilForce(Vector3 originalPosition)
        {
            _shooted = true;

            _originalPosition = originalPosition;
            _recoilPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z - RecoilForce);

            _previousPosition = originalPosition;
        }
    }
}
