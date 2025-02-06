using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "ScriptableObjects/Achievement")]
public class Achievement : ScriptableObject
{
    public string achievementName;
    public string description;
    public bool isUnlocked;
    public double requiredXp;
    public int requiredLevel;
    public int requiredKills;
}