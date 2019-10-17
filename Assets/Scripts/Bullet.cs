using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maximumLifeTime = 2f;
    private float currentLifeTime;
    public GameObject hitEffect;
    public float damage = 1;

    private void Start()
    {
        currentLifeTime = 0;
    }

    private void Update()
    {
        if (currentLifeTime >= maximumLifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            currentLifeTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            AudioManager.instance.Play("Hit_Hurt");
            EnemyStats enemy = collision.collider.GetComponent<EnemyStats>();

            enemy.takeDamage(damage);
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect.gameObject, 1f);

    }
}
