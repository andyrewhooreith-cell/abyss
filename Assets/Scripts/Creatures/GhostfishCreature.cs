using UnityEngine;

namespace Abyss.Creatures
{
    /// <summary>
    /// Ghostfish - A bioluminescent creature that glows in the deep.
    /// Behavior: Aggressive, chases player with moderate speed.
    /// </summary>
    public class GhostfishCreature : SeaCreature
    {
        [SerializeField] private float chargeCooldown = 3f;
        private float timeSinceLastCharge = 0f;
        private bool isCharging = false;

        protected override void Start()
        {
            base.Start();
            creatureName = "Ghostfish";
            maxHealth = 25f;
            moveSpeed = 3.5f;
            damage = 8f;
            treasureReward = 25;
        }

        protected override void Update()
        {
            base.Update();
            timeSinceLastCharge += Time.deltaTime;
        }

        /// <summary>
        /// Ghostfish performs a charging attack when close enough.
        /// </summary>
        protected override void ChasePlayer()
        {
            if (playerTransform == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            // Perform a charge attack periodically
            if (distanceToPlayer < 5f && timeSinceLastCharge > chargeCooldown)
            {
                isCharging = true;
                timeSinceLastCharge = 0f;
            }

            Vector2 direction = (playerTransform.position - transform.position).normalized;
            float speed = isCharging ? moveSpeed * 2f : moveSpeed;

            if (rb != null)
            {
                rb.velocity = direction * speed;
            }
        }
    }
}
