namespace Abyss.Utilities
{
    /// <summary>
    /// Global constants used throughout the Abyss game.
    /// </summary>
    public static class Constants
    {
        // Depth progression
        public const int DEPTH_INCREMENT = 10;
        public const int MAX_DEPTH = 1000;

        // Creature difficulty scaling
        public const float HEALTH_SCALE_PER_DEPTH = 1.05f;
        public const float DAMAGE_SCALE_PER_DEPTH = 1.02f;
        public const float SPEED_SCALE_PER_DEPTH = 1.01f;

        // Player stats
        public const float PLAYER_BASE_HEALTH = 100f;
        public const float PLAYER_BASE_SPEED = 5f;
        public const float PLAYER_BASE_DAMAGE = 15f;

        // Treasure and rewards
        public const int BASE_TREASURE_REWARD = 10;
        public const float TREASURE_SCALE_PER_DEPTH = 1.1f;
    }
}
