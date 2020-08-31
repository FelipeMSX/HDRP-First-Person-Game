using UnityEngine;

namespace Assets.Scripts
{
    public class BehaviourJump : MonoBehaviour, IBehaviourJump
    {

        [SerializeField]
        private float _gravity = -25f;
        public float Gravity
        {
            get => _gravity;
            set => _gravity = value;
        }

        [SerializeField]
        private float _jumpForce = 50f;
        public float JumpForce
        {
            get => _jumpForce;
            set => _jumpForce = value;
        }

        [SerializeField]
        private float _jumpTimer = 0.3f;
        public float JumpTimer
        {
            get => _jumpTimer;
            set => _jumpTimer = value;
        }

        [SerializeField]
        public Transform _groundCheck;
        public Transform GroundCheck
        {
            get => _groundCheck;
            set => _groundCheck = value;
        }

        [SerializeField]
        private float _groundDistance = 0.4f;
        public float GroundDistance
        {
            get => _groundDistance;
            set => _groundDistance = value;
        }

        [SerializeField]
        private LayerMask _groundMask;
        //Se eu quero indentificar que um player tocou o chão é com isso aqui.
        public LayerMask GroundMask
        {
            get => _groundMask;
            set => _groundMask = value;
        }

        [SerializeField]
        private bool _isJumpPressed;
        public bool IsJumpPressed 
        {
            get => _isJumpPressed;
            set => _isJumpPressed = value;
        }

        private Vector3 _gravityVelocityControl;

        //Tempo em que o pulo pode ser aumentado.
        private float _jumpTimerCount = 0.3f;

        //Indica se o jogador está no chão.
        private bool _isGrounded;

        private bool _isFirstJump;

        private CharacterController _characterController;

        public void Jump()
        {
            if (_isGrounded)
            {
                _gravityVelocityControl.y = Mathf.Sqrt(JumpForce);
                _isFirstJump = true;
            }
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();

        }

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(GroundCheck.position, _groundDistance, GroundMask);

            if (!_isGrounded)
            {
                _jumpTimerCount -= Time.deltaTime;
            }

            if (_isGrounded && _gravityVelocityControl.y < 0)
                _gravityVelocityControl.y = -2f;

            //Incrementa o tamanho do pulo
            if (IsJumpPressed && _isFirstJump && _jumpTimerCount > 0f)
            {
                _gravityVelocityControl.y = Mathf.Sqrt(JumpForce + JumpForce * _jumpTimerCount);
            }
            else if (_isGrounded && _jumpTimerCount < 0f)
            {
                _jumpTimerCount = JumpTimer;
                _isFirstJump = false;
            }

            _gravityVelocityControl.y += Gravity * Time.deltaTime;
            _characterController.Move(_gravityVelocityControl * Time.deltaTime);

        }
    }
}
