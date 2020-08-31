using UnityEngine;

namespace Assets.Scripts
{
    public class BehaviourPlayerMovement : MonoBehaviour, IBehaviourMove
    {

        private CharacterController _characterController;
        private Player _player;

        private Vector2 _aswdMovement;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            Vector3 newMove = _player.transform.right * _aswdMovement.x + _player.transform.forward * _aswdMovement.y;

            _characterController.Move(newMove * _player.Speed * Time.deltaTime);
        }

        public void Move(Vector2 move)
        {
            _aswdMovement = move;
        }
    }
}
