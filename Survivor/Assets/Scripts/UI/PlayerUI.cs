using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthBar;
    public Image healthFill; // Image du remplissage de la barre
    public Slider xpBar;
    public Text xpText;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (healthBar != null && player != null)
        {
            healthBar.maxValue = player.MaxHealth;
            healthBar.value = player.Health;
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
            healthBar.value = healthPercent; // ✅ Valeur entre 0 et 1
    
            // 🎨 Changement de couleur en fonction de la vie
            if (healthFill != null)
            {
                if (healthPercent > 0.5f)
                    healthFill.color = Color.green; // ✅ Vert si vie > 50%
                else if (healthPercent > 0.15f)
                    healthFill.color = new Color(1f, 0.5f, 0f); // ✅ Orange si 15% < vie < 50%
                else
                    healthFill.color = Color.red; // ✅ Rouge si vie < 15%
            }
        }
    
        if (xpBar != null && xpText != null && player != null)
        {
            double xpToNextLevel = player.getXpToNextLevel();
            xpBar.value = (float)(player.getCurrentXP() / xpToNextLevel);
            xpText.text = "Niveau " + player.getLevel() + " | XP : " + player.getCurrentXP() + " / " + xpToNextLevel;
        }
    }

}
