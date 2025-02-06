using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.IO;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievements;

    private PlayerController player;

    public UnityEvent OnPlayerLeveledUp;
    public UnityEvent OnPlayerGetXP;

    public static int totalKills = 0;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();

        LoadAchievements();
    }

    void Destroy()
    {
        SaveAchievements();
    }

    void FixedUpdate()
    {
        CheckAchievements();
    }

     void CheckAchievements()
    {
        foreach (var achievement in achievements)
        {
            if (!achievement.isUnlocked)
            {
                if (totalKills >= achievement.requiredKills && player.totalXP >= achievement.requiredXp && player.level >= achievement.requiredLevel)
                {
                    UnlockAchievement(achievement);
                }
            }
        }
    }

    void UnlockAchievement(Achievement achievement)
    {
        achievement.isUnlocked = true;
        SaveAchievements();
        Debug.Log("Achievement Unlocked: " + achievement.achievementName);
    }

    bool hasAchievement(string achievementName)
    {
        foreach (var achievement in achievements)
        {
            if (achievement.achievementName == achievementName)
            {
                return achievement.isUnlocked;
            }
        }
        return false;
    }

    void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.achievementName, achievement.isUnlocked ? 1 : 0);
        }
    }

    void LoadAchievements()
    {
        foreach (var achievement in achievements)
        {
            achievement.isUnlocked = PlayerPrefs.GetInt(achievement.achievementName) == 1;
        }
    }

    void OnApplicationQuit()
    {
        SaveAchievements();
    }
}
