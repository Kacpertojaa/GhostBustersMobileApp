using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ShootButton shootButton;
    public Transform firePoint;
    public GameObject bullet;
    public PayerMove playerMove;
    private float timer = 0.0f;
    private float waitTime = 0.5f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (shootButton.isShooting && timer > waitTime && playerMove.IsGrounded())
        {
            Shoot();
            timer = 0.0f;
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
