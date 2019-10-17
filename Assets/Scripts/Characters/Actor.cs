using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public void Move(Vector2 dir, Rigidbody2D rb, float speed)
    {
        float pen = 1;
        if ((dir.x > 0.5f || dir.x < -0.5f) && (dir.y > 0.5f || dir.y < -0.5f))
        {
            pen = 1.35f;
        }

        rb.velocity = dir.normalized * speed * pen;
    }

    public void Aim(Vector3 target)
    {
        Vector2 dir = transform.position - target;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    public void FireStrong(Transform firePoint, float bulletForce, GameObject strongBulletPrefab)
    {
        GameObject bullet = Instantiate(strongBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void FireContinuous(Transform firePoint, float bulletForce, GameObject continuousBulletPrefab)
    {
        GameObject bullet = Instantiate(continuousBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
