using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        [Tooltip("Maximum amount of health"),SerializeField]
        public float _maxHealth = 10f;

        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        [Tooltip("Maximum amount of health"), SerializeField]
        private float _currentHealth;
        public float CurrentHealth 
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        [Tooltip("Indicates with the object can suffer damage"), SerializeField]
        private bool _invincible;
        public bool Invincible 
        {
            get => _invincible;
            set => _invincible = value; 
        }

        /// <summary>
        /// Occurs when the player suffers some kind of damage.
        /// <para>float: Amount of Damage, GameObject: Source of Damage</para>
        /// </summary>
        public UnityAction<float, GameObject> OnDamaged;

        /// <summary>
        /// Occurs when the player heals with a amount of life. 
        /// <para>float: Amount of life healed</para>
        /// </summary>
        public UnityAction<float> OnHealed;

        /// <summary>
        /// Occurs when the player is going to be killed. 
        /// </summary>
        public UnityAction OnDie;

        private bool _isDead;


        public bool CanPickup() => CurrentHealth < MaxHealth;

        public void Heal(float healAmount)
        {
            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            OnHealed?.Invoke(healAmount);
        }

        public void TakeDamage(float damage, GameObject damageSouce)
        {
            if (Invincible)
                return;

            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            OnDamaged?.Invoke(damage, damageSouce);

            HandleDeath();
        }
        public void Kill()
        {
            CurrentHealth = 0f;

            OnDamaged?.Invoke(MaxHealth, null);

            HandleDeath();
        }

        private void HandleDeath()
        {
            if (_isDead)
                return;

            if(CurrentHealth <= 0f) 
            {
                _isDead = true;
                OnDie?.Invoke();
            }
        }
    }
}
