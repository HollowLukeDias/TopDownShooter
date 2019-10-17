using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    //Dying
    private bool isDead = false;
    //Health
    public Image healthBar;
    public float maxHealth = 10;
    private static float health;
    //Speed
    public float speed = 10;
    //Money
    private float money = 0;
    private float totalMoneyGained = 0;
    //Experience
    private float XP = 0;
    public float initialXPToNextLevel = 100;
    private float XPToNextLevel;
    public static int timesLeveledUp = 0;
    //Score
    private float score;

    private void Start()
    {
        XPToNextLevel = initialXPToNextLevel;
        health = maxHealth;
    }

    private void Update()
    {

        healthBar.fillAmount = (health / maxHealth);
    }

    //Money
    public void GainMoney(float amount)
    {
        money += amount;
        totalMoneyGained += amount;
    }

    public void SpendMoney(float amount)
    {
        money -= amount;
    }
    public float GetMoney()
    {
        return money;
    }

    //Experience
    public float GetXP()
    {
        return XP;
    }
    public float GetNextLevel()
    {
        return XPToNextLevel;
    }
    public void GainXP(float amount)
    {
        
        if ((XP + amount) >= this.XPToNextLevel)
        {
            LevelUp();
            XP = amount + (XPToNextLevel - XP);
            XPToNextLevel = GetNextXPToNextLevel();
        }
        else
        {
            XP += amount;
        }
    }

    private float GetNextXPToNextLevel()
    {
    
        timesLeveledUp++;
        return Mathf.Pow((initialXPToNextLevel), (1 + (timesLeveledUp / 10f)));
    }

    private void LevelUp()
    {
        AudioManager.instance.Play("LevelUp");
        SetSpeed(Mathf.Pow(speed, (1.05f)));
        SetMaxHealth(Mathf.Pow(maxHealth, (1.1f)));   
    }

    //Speed
    private void SetSpeed(float amount)
    {
        speed = amount;
    }
    //Health
    private void SetMaxHealth(float amount)
    {
        health += amount - maxHealth;
        maxHealth = amount;

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health<=0 && !isDead)
        {
            isDead = false;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("health is 0");
    }

    //score
    public void CalculateScore()
    {

    }

    public void KilledEnemy(float money, float XP)
    {
        GainXP(XP);
        GainMoney(money);
    }
}
