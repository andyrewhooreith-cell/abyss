using UnityEngine;
using Abyss.Core;

namespace Abyss.Creatures
{
    /// <summary>
    /// Base class for all sea creatures in the abyss.
    /// Inherit from this to create specific creature types.
    /// </summary>
    public abstract class SeaCreature : MonoBehaviour
    {
        [SerializeField] protected string creatureName = "Unknown Creature";
        [SerializeField] protected float maxHealth = 30f;
        [SerializeField] protected float currentHealth;
        [SerializeField] protected float moveSpeed = 2f;
        [SerializeField] protected float damage = 5f;
        [SerializeField] protected float detectionRange = 10f;
        [SerializeField] protected int treasureReward = 10;

        protected Rigidbody2D rb;
        protected Transform playerTransform;
        protected bool isAlive = true;

        protected virtual void Start()
        {
            currentHealth = maxHealth;
            rb = GetComponent<Rigidbody2D>();
            
            // Find player in scene
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                playerTransform = playerObj.transform;
            }
        }

        protected virtual void Update()
        {
            if (!isAlive) return;

            if (playerTransform != null)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

                if (distanceToPlayer < detectionRange)
                {
                    ChasePlayer();
                }
                else
                {
                    Idle();
                }
            }
        }

        /// <summary>
        /// Move towards the player.
        /// </summary>
        protected virtual void ChasePlayer()
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            if (rb != null)
            {
                rb.velocity = direction * moveSpeed;
            }
        }

        /// <summary>
        /// Creature idle behavior (can be overridden).
        /// </summary>
        protected virtual void Idle()
        {
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }

        /// <summary>
        /// Deal damage to the player on contact.
        /// </summary>
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var player = collision.GetComponent<Player.PlayerController>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }

        /// <summary>
        /// Take damage from player attacks.
        /// </summary>
        public virtual void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount;
            Debug.Log($"{creatureName} took {damageAmount} damage! Health: {currentHealth}/{maxHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Handle creature death.
        /// </summary>
        protected virtual void Die()
        {
            isAlive = false;
            Debug.Log($"{creatureName} defeated!");
            GameManager.Instance.DefeatCreature();
            GameManager.Instance.CollectTreasure(treasureReward);
            Destroy(gameObject);
        }

        // Getters
        public float GetHealth() => currentHealth;
        public float GetMaxHealth() => maxHealth;
        public bool IsAlive() => isAlive;
    }
}
