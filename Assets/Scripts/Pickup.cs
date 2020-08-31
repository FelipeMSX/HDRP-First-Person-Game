using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Pickup : MonoBehaviour
    {

        [Tooltip("Frequency at which the item will move up and down"),SerializeField]
        private float _verticalBobFrequency = 1f;
        public float VerticalBobFrequency
        {
            get => _verticalBobFrequency;
            set => _verticalBobFrequency = value;
        }

        [Tooltip("Distance the item will move up and down"), SerializeField]
        private float _bobbingAmount = 1f;
        public float BobbingAmount 
        {
            get => _bobbingAmount;
            set => _bobbingAmount = value;
        }

        [Tooltip("Rotation angle per second"),SerializeField]
        private float _rotatingSpeed = 360f;
        public float RotatingSpeed
        {
            get => _rotatingSpeed;
            set => _rotatingSpeed = value;
        }

        [Tooltip("Sound played on pickup"),SerializeField]
        private AudioClip _pickupSFX;
        public AudioClip PickupSFX 
        {
            get => _pickupSFX;
            set => _pickupSFX = value;
        }

        [Tooltip("VFX spawned on pickup"),SerializeField]
        private GameObject _pickupVFXPrefab;

        public GameObject PickupVFXPrefab 
        {
            get => _pickupVFXPrefab;
            set => _pickupVFXPrefab = value; 
        }

        public UnityAction<Player> OnPick;

        public Rigidbody PickupRigidbody { get; private set; }

        //Inital position of the gameobject;
        private Vector3 _startPosition;

        private void Start()
        {
            PickupRigidbody = GetComponent<Rigidbody>();
            Collider collider = GetComponent<Collider>();

            // ensure the physics setup is a kinematic rigidbody trigger
            PickupRigidbody.isKinematic = true;
            collider.isTrigger = true;

            // Remember start position for animation
            _startPosition = transform.position;
        }

        private void Update()
        {
            // Handle bobbing
            float bobbingAnimationPhase = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.5f) + 0.5f) * BobbingAmount;
            transform.position = _startPosition + Vector3.up * bobbingAnimationPhase;

            // Handle rotating
            transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
        }

        private void OnTriggerEnter(Collider other)
        {
            Player pickingPlayer = other.GetComponent<Player>();

            if (pickingPlayer != null && OnPick != null)
            {
                OnPick.Invoke(pickingPlayer);
            }
        }
        public void PlayPickupFeedback()
        {
           if (PickupSFX != null)
            {
                AudioSource.PlayClipAtPoint(PickupSFX, Camera.main.transform.position,1f);
                //AudioUtility.CreateSFX(pickupSFX, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
            }

            if (PickupVFXPrefab != null)
            {
                var pickupVFXInstance = Instantiate(PickupVFXPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
