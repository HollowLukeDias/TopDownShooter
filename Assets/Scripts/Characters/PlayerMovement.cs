using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats playerStats;
    public Rigidbody2D rb;
    public Actor actor;
    public Transform firePoint;
    //Strong Bullet
    public float strongBulletForce = 10;
    public float timeToShootStrong;
    public float InitialTimeToShootStrong = .75f;
    public GameObject strongBulletPrefab;
    //continuous bullet
    public float continuousBulletForce = 10;
    public float InitialTimeToShootContinuous = .10f;
    private float timeToShootContinuous;
    public GameObject continuousBulletPrefab;
    Vector2 mousePos;
    Vector2 moveDirection;
    public Camera cam;

    private void Start()
    {
        timeToShootStrong = InitialTimeToShootStrong;
        timeToShootContinuous = InitialTimeToShootContinuous;
        actor = GetComponent<Actor>();
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonDown(0) && timeToShootStrong<=0)
        {
            actor.FireStrong(this.firePoint, this.strongBulletForce,this.strongBulletPrefab);
            timeToShootStrong = InitialTimeToShootStrong;
        }
        if (Input.GetMouseButton(1) && timeToShootContinuous<=0)
        {
            actor.FireContinuous(this.firePoint, this.continuousBulletForce, this.continuousBulletPrefab);
            timeToShootContinuous = InitialTimeToShootContinuous;
        }


        timeToShootContinuous -= Time.deltaTime;
        timeToShootStrong -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        actor.Aim(mousePos);
        actor.Move(new Vector2(moveDirection.x, moveDirection.y), this.rb, playerStats.speed);
    }

}
