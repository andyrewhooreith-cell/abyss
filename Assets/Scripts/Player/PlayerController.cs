using UnityEngine;
using Abyss.Core;

namespace Abyss.Player
{
    /// <summary>
    /// Controls player movement, interaction, and basic stats.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;
        [SerializeField] private Rigidbody2D rb;

        private Vector2 moveInput;
        private Vector2 moveDirection = Vector2.zero;

        private void Start()
        {
            currentHealth = maxHealth;
            rb = GetComponent<Rigidbody2D>();
            
            if (rb == null)
            {
                Debug.LogError("PlayerController requires a Rigidbody2D component!");
            }
        }

        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            Move();
        }

        /// <summary>
        /// Handle player input for movement.
        /// </summary>
        private void HandleInput()
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
            moveDirection = moveInput.normalized;
        }

        /// <summary>
        /// Apply movement to the player.
        /// </summary>
        private void Move()
        {
            if (rb != null)
            {
                rb.velocity = moveDirection * moveSpeed;
            }
        }

        /// <summary>
        /// Take damage from creatures or environmental hazards.
        /// </summary>
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Player hit! Health: {currentHealth}/{maxHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Heal the player.
        /// </summary>
        public void Heal(float amount)
        {
            currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
            Debug.Log($"Player healed! Health: {currentHealth}/{maxHealth}");
        }

        /// <summary>
        /// Handle player death.
        /// </summary>
        private void Die()
        {
            Debug.Log("Player died!");
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }

        // Getters
        public float GetHealth() => currentHealth;
        public float GetMaxHealth() => maxHealth;
        public float GetHealthPercentage() => currentHealth / maxHealth;
    }
}
