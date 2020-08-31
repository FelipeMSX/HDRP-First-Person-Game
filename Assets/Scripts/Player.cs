using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class Player : Actor
    {
        [SerializeField]
        private IBehaviourMove _behaviourMove;
        public IBehaviourMove BehaviourMove
        {
            get => _behaviourMove;
            set => _behaviourMove = value;
        }

        [SerializeField]
        private IBehaviourJump _behaviourJump;
        public IBehaviourJump BehaviourJump
        {
            get => _behaviourJump;
            set => _behaviourJump = value;
        }


        [SerializeField]
        private CharacterController _characterController;
        public CharacterController CharacterController
        {
            get => _characterController;
            set => _characterController = value;
        }

        [SerializeField]
        private float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        [SerializeField]
        private Health _health;
        public Health Health
        {
            get => _health;
            set => _health = value;
        }

        public bool IsMoving{ get; private set; }


        [SerializeField]
        private PlayerHealthGameEvent OnPlayerHealthChanged = null;


        private void Start()
        {
            BehaviourMove = GetComponent<IBehaviourMove>();
            BehaviourJump = GetComponent<IBehaviourJump>();

            _health = GetComponent<Health>();

            _health.OnDamaged += OnDamaged;
            _health.OnHealed += OnHealed;

            //Atualiza a GUI com a atual vida do player.
            OnPlayerHealthChanged?.Raise(Health);
        }


        public void JumpCanceled(InputAction.CallbackContext obj)
        {
            BehaviourJump.IsJumpPressed = false;
        }

        public void JumpStarted(InputAction.CallbackContext obj)
        {

            BehaviourJump.IsJumpPressed = true;
            BehaviourJump.Jump();
        }

        public void MovePerformed(InputAction.CallbackContext obj)
        {
            Vector2 movVector = obj.ReadValue<Vector2>();
            Move(movVector);

            IsMoving = movVector.x != 0f || movVector.y != 0f;
        }


        public void Move(Vector2 move)
        {
            BehaviourMove.Move(move);
        }

        private void OnDamaged(float damage, GameObject source)
        {
            OnPlayerHealthChanged.Raise(Health);
        }

        private void OnHealed(float amount)
        {
            OnPlayerHealthChanged.Raise(Health);
        }

        private void OnDestroy()
        {
            _health.OnDamaged -= OnDamaged;
            _health.OnHealed -= OnHealed;
        }
    }
}
