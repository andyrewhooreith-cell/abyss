using UnityEngine;
using System.Collections.Generic;

namespace Abyss.Dungeon
{
    /// <summary>
    /// Procedurally generates dungeon levels based on current depth.
    /// Creates unique underground caverns with creatures and treasures.
    /// </summary>
    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] private int roomCount = 5;
        [SerializeField] private Vector2 roomSize = new Vector2(20f, 15f);
        [SerializeField] private GameObject creaturePrefab;
        [SerializeField] private int maxCreaturesPerRoom = 3;

        private int currentSeed = 0;

        /// <summary>
        /// Generate a new dungeon level.
        /// </summary>
        public void GenerateLevel(int depth)
        {
            currentSeed = depth; // Use depth as seed for consistency
            Random.InitState(currentSeed);

            Debug.Log($"Generating dungeon for depth {depth}...");

            // Clear existing level
            ClearLevel();

            // Generate rooms
            GenerateRooms();

            // Spawn creatures based on difficulty
            SpawnCreatures(depth);

            Debug.Log("Dungeon generation complete!");
        }

        /// <summary>
        /// Generate room layouts.
        /// </summary>
        private void GenerateRooms()
        {
            for (int i = 0; i < roomCount; i++)
            {
                Vector3 roomPosition = new Vector3(i * roomSize.x, Random.Range(-5f, 5f), 0);
                
                // TODO: Create room visual representation
                // Create floor, walls, etc.
                Debug.Log($"Generated room {i + 1} at position {roomPosition}");
            }
        }

        /// <summary>
        /// Spawn creatures appropriate to the current depth.
        /// </summary>
        private void SpawnCreatures(int depth)
        {
            int creatureCount = Mathf.Min(maxCreaturesPerRoom * roomCount, depth / 10 + 2);

            for (int i = 0; i < creatureCount; i++)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-50f, 50f),
                    Random.Range(-20f, 20f),
                    0
                );

                // TODO: Spawn creature based on depth
                Debug.Log($"Spawning creature at {spawnPosition}");
            }
        }

        /// <summary>
        /// Clear the current level.
        /// </summary>
        private void ClearLevel()
        {
            // Destroy all creatures and level objects
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
