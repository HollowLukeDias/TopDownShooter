using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static int amountOfEnemies;
    public Actor actor;
    public float damage;
    public EnemyStats enemyStats;
    public PlayerStats player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        player.transform.position = player.GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.transform.position- this.transform.position;
            actor.Move(dir, rb, enemyStats.speed);
            actor.Aim(player.transform.position);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            DamagePlayer(damage);
        }
    }

    public void DamagePlayer(float damage)
    {
        player.TakeDamage(damage);
        enemyStats.Die();
    }

}
