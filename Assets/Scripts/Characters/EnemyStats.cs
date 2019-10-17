using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject deathEffect;
    public PlayerStats playerStats;
    public static int enemiesKilled;
    //Dying
    private bool isDead = false;
    //Health
    public Image healthBar;
    public float maxHealth = 10;
    private  float health;
    //Speed
    public float speed = 5;
    //Worth
    private float moneyWorth = 10;
    //Experience
    private float XPworth = 10;
    private int timesLeveledUp = 0;
    //Score
    private float score;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        health = maxHealth;
        //for (int i = 0; i < timesLeveledUp; i++)
        //{
        //    LevelUp();
        //}
    }

    private void Update()
    {
        this.healthBar.fillAmount = (health / maxHealth);
    }


    //Money
    public void SetMoneyWorth(float amount)
    {
        moneyWorth = amount;
    }
    //Experience
    private void LevelUp()
    {
        SetSpeed(Mathf.Pow(speed,(1.05f)));
        SetMaxHealth(Mathf.Pow(health, (1.2f)));
        SetXPWorth(Mathf.Pow(XPworth, (1.15f)));
        SetMoneyWorth(Mathf.Pow(moneyWorth, (1.1f)));
    }

    private void SetXPWorth(float amount)
    {
        XPworth = amount;
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

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && !isDead)
        {
            enemiesKilled++;
            playerStats.KilledEnemy(moneyWorth, XPworth);
            isDead = true;
            Die();
        }
    }

    public void Die()
    {
        AudioManager.instance.Play("EnemyDeath");
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, 1.5f);
        Destroy(this.gameObject);
    }
}
