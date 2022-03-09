using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool isFire = false;
    public float TimebetweenBullets;
    public float attackSpeed;
    public float bulletspeed;
    
    public GameObject bulletPrefab;
    public BulletController Bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
           isFire = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isFire = false;
        }
        
        if (isFire) {
            attackSpeed -= Time.deltaTime;
            if (attackSpeed <= 0) {
                attackSpeed = TimebetweenBullets;
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
