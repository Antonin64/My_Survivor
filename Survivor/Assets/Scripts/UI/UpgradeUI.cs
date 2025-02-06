using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UpgradeUI : MonoBehaviour
{
    public UpgradeSelector upgradeSelector;
    public Button[] upgradeButtons;
    public Image[] upgradeImages;
    public Text titleText;
    public Text descriptionText;
    
    private List<IUpgrade> selectedUpgrades;

    void Start()
    {
        gameObject.SetActive(false); // Cache l'UI au démarrage
    }

    public void ShowUpgradeChoices()
    {
        selectedUpgrades = upgradeSelector.SelectRandomUpgrades(3);
        gameObject.SetActive(true); // 🖥️ Afficher l'UI

        for (int i = 0; i < selectedUpgrades.Count; i++)
        {
            IUpgrade upgrade = selectedUpgrades[i];
            upgradeImages[i].sprite = upgrade.CardSprite;
            upgradeButtons[i].onClick.RemoveAllListeners();
            upgradeButtons[i].onClick.AddListener(() => SelectUpgrade(upgrade));

            int index = i;
            upgradeButtons[i].onClick.AddListener(() => UpdateDescription(selectedUpgrades[index]));
        }

        titleText.text = "Choisissez une amélioration";
        descriptionText.text = "";
    }

    void UpdateDescription(IUpgrade upgrade)
    {
        descriptionText.text = "Effet : " + upgrade.GetType().Name;
    }

    public void SelectUpgrade(IUpgrade upgrade)
    {
        upgrade.Apply(FindObjectOfType<PlayerController>());
        gameObject.SetActive(false); // 🚪 Cache l’UI après sélection
    }
}
