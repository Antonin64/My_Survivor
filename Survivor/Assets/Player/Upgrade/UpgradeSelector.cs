using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelector : MonoBehaviour
{
    public List<IUpgrade> allUpgrades; // Liste contenant toutes les cartes possibles
    private List<IUpgrade> selectedUpgrades = new List<IUpgrade>();

    public List<IUpgrade> SelectRandomUpgrades(int count)
    {
        List<IUpgrade> weightedPool = new List<IUpgrade>();

        //Remplir une "pool" pondérée selon les probabilités de drop
        foreach (IUpgrade upgrade in allUpgrades)
        {
            float probability = (upgrade as MonoBehaviour).GetComponent<IUpgrade>().DropChance;

            for (int i = 0; i < probability; i++) // Plus la chance est haute, plus l'upgrade est ajoutée
            {
                weightedPool.Add(upgrade);
            }
        }

        //Tirer aléatoirement 3 cartes différentes
        selectedUpgrades.Clear();
        for (int i = 0; i < count; i++)
        {
            if (weightedPool.Count == 0) break; // Évite une erreur si plus assez de cartes

            int randomIndex = Random.Range(0, weightedPool.Count);
            selectedUpgrades.Add(weightedPool[randomIndex]);

            //Supprimer toutes les instances de cette carte pour éviter les doublons
            weightedPool.RemoveAll(x => x == weightedPool[randomIndex]);
        }

        return selectedUpgrades;
    }
}
