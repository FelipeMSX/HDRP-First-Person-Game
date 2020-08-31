using UnityEngine;

namespace Assets.Scripts
{
    public class PickupHealth : MonoBehaviour
    {
        [Tooltip("Amount of health to heal on pickup"), SerializeField]
        private float _healAmount = 10f;
        public float HealAmount
        {
            get => _healAmount;
            set => _healAmount = value;
        }

        private Pickup _pickup;

        void Start()
        {
            _pickup = GetComponent<Pickup>();

            // Subscribe to pickup action
            _pickup.OnPick += OnPicked;
        }

        void OnPicked(Player player)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth && playerHealth.CanPickup())
            {
                playerHealth.Heal(_healAmount);
                _pickup.PlayPickupFeedback();

                //Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {

            // Subscribe to pickup action to avoid memory leak.
            _pickup.OnPick -= OnPicked;
        }
    }
}
