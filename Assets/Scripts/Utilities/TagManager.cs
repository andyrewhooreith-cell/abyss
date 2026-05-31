using UnityEngine;

namespace Abyss.Utilities
{
    /// <summary>
    /// Helper class for managing game tags.
    /// Make sure these tags exist in your Unity project!
    /// </summary>
    public static class TagManager
    {
        public const string PLAYER_TAG = "Player";
        public const string CREATURE_TAG = "Creature";
        public const string TREASURE_TAG = "Treasure";
        public const string HAZARD_TAG = "Hazard";
        public const string WALL_TAG = "Wall";

        /// <summary>
        /// Ensure all required tags exist (call from editor script).
        /// </summary>
        public static void ValidateTags()
        {
            #if UNITY_EDITOR
            string[] requiredTags = { PLAYER_TAG, CREATURE_TAG, TREASURE_TAG, HAZARD_TAG, WALL_TAG };
            
            foreach (string tag in requiredTags)
            {
                if (!TagExists(tag))
                {
                    Debug.LogWarning($"Tag '{tag}' does not exist. Please create it in the tag manager.");
                }
            }
            #endif
        }

        #if UNITY_EDITOR
        private static bool TagExists(string tag)
        {
            return System.System.Collections.Generic.List<string> tags = 
                new System.Collections.Generic.List<string>(UnityEditorInternal.InternalEditorUtility.tags);
            return tags.Contains(tag);
        }
        #endif
    }
}
