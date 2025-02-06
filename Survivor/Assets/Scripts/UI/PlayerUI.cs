using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthBar;
    public Image healthFill;
    public Slider xpBar;
    public Text xpText;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.LogError("PlayerController non trouvé !");
            return;
        }

        // Initialisation des valeurs de la barre de vie
        if (healthBar != null)
        {
            healthBar.maxValue = 1;
            healthBar.value = Mathf.Clamp01(player.Health / player.MaxHealth);
        }

        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthBar != null && player != null)
        {
            float healthPercent = Mathf.Clamp01(player.Health / player.MaxHealth);
            healthBar.value = healthPercent;

            // Changement de couleur dynamique de la barre de vie
            if (healthFill != null)
            {
                if (healthPercent > 0.5f)
                    healthFill.color = Color.green;
                else if (healthPercent > 0.15f)
                    healthFill.color = new Color(1f, 0.5f, 0f);
                else
                    healthFill.color = Color.red;
            }
        }

        // 🔹 Mise à jour de l'XP et du niveau
        if (xpBar != null && xpText != null && player != null)
        {
            double xpToNextLevel = player.getXpToNextLevel();
            float xpRatio = (float)(player.getCurrentXP() / xpToNextLevel);

            xpBar.value = Mathf.Clamp01(xpRatio);
            xpText.text = "Niveau " + player.getLevel() + " | XP : " + player.getCurrentXP() + " / " + xpToNextLevel;
        }
    }
}
