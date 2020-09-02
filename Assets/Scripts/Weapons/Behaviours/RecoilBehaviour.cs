using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{
    public class RecoilBehaviour : MonoBehaviour, IRecoilBehaviour
    {
        public float RecoilForce = 1f;
        public float Speed = 1.5f;

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

        public void AddRecoilForce()
        {
            _shooted = true;

            _originalPosition = gameObject.transform.localPosition;
            _recoilPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - RecoilForce);

            _previousPosition = gameObject.transform.localPosition;
        }
    }
}
