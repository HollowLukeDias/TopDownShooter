using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI enemiesKilled;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI continuousDamage;
    public TextMeshProUGUI strongDamage;
    public TextMeshProUGUI enemiesToNextWave;
    public Image XPImage;
    public PlayerStats playerStats;

    private void FixedUpdate()
    {
        moneyText.text = string.Format("{0:0.00}", playerStats.GetMoney());
        XPImage.fillAmount = playerStats.GetXP() / playerStats.GetNextLevel();
        enemiesKilled.text = EnemyStats.enemiesKilled.ToString();
        currentLevel.text = "Level " + (PlayerStats.timesLeveledUp + 1).ToString();
        speed.text = string.Format("{0:0.00}", playerStats.speed);
    }

}
