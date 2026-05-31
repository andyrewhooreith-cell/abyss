using UnityEngine;
using UnityEngine.UI;
using Abyss.Core;

namespace Abyss.UI
{
    /// <summary>
    /// Manages all UI elements and HUD display.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text depthText;
        [SerializeField] private Text healthText;
        [SerializeField] private Text treasureText;
        [SerializeField] private Text creaturesDefeatedText;
        [SerializeField] private Image healthBar;

        private Player.PlayerController playerController;

        private void Start()
        {
            // Find player in scene
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                playerController = playerObj.GetComponent<Player.PlayerController>();
            }
        }

        private void Update()
        {
            UpdateUI();
        }

        /// <summary>
        /// Update all UI elements.
        /// </summary>
        private void UpdateUI()
        {
            if (GameManager.Instance != null)
            {
                if (depthText != null)
                    depthText.text = $"Depth: {GameManager.Instance.GetCurrentDepth()}m";
                
                if (treasureText != null)
                    treasureText.text = $"Treasure: {GameManager.Instance.GetTreasureCollected()}";
                
                if (creaturesDefeatedText != null)
                    creaturesDefeatedText.text = $"Creatures: {GameManager.Instance.GetCreaturesDefeated()}";
            }

            if (playerController != null)
            {
                if (healthText != null)
                    healthText.text = $"Health: {playerController.GetHealth():F0}/{playerController.GetMaxHealth():F0}";
                
                if (healthBar != null)
                    healthBar.fillAmount = playerController.GetHealthPercentage();
            }
        }
    }
}
