using UnityEngine;
using UnityEngine.SceneManagement;

namespace Abyss.Core
{
    /// <summary>
    /// Manages overall game state, progression, and scene transitions.
    /// Singleton pattern to ensure only one GameManager exists.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private int currentDepth = 0;
        [SerializeField] private int maxDepth = 100;
        [SerializeField] private int creaturesDefeated = 0;
        [SerializeField] private int treasureCollected = 0;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            Debug.Log("Game Manager initialized. Ready to dive into the abyss!");
        }

        /// <summary>
        /// Move to the next depth level.
        /// </summary>
        public void DiveDeeper()
        {
            if (currentDepth < maxDepth)
            {
                currentDepth++;
                Debug.Log($"Diving deeper... Current depth: {currentDepth}m");
                // TODO: Generate new level at current depth
            }
            else
            {
                Debug.Log("You've reached the deepest point of the abyss!");
            }
        }

        /// <summary>
        /// Called when player is defeated or dies.
        /// </summary>
        public void GameOver()
        {
            Debug.Log($"Game Over! You reached depth {currentDepth}m and defeated {creaturesDefeated} creatures.");
            ResetRun();
            // TODO: Show game over screen with stats
        }

        /// <summary>
        /// Reset the run to start a new dive.
        /// </summary>
        public void ResetRun()
        {
            currentDepth = 0;
            creaturesDefeated = 0;
            treasureCollected = 0;
        }

        /// <summary>
        /// Increment creature defeated counter.
        /// </summary>
        public void DefeatCreature()
        {
            creaturesDefeated++;
            Debug.Log($"Creatures defeated: {creaturesDefeated}");
        }

        /// <summary>
        /// Add collected treasure to counter.
        /// </summary>
        public void CollectTreasure(int amount)
        {
            treasureCollected += amount;
            Debug.Log($"Total treasure collected: {treasureCollected}");
        }

        // Getters
        public int GetCurrentDepth() => currentDepth;
        public int GetMaxDepth() => maxDepth;
        public int GetCreaturesDefeated() => creaturesDefeated;
        public int GetTreasureCollected() => treasureCollected;
    }
}
