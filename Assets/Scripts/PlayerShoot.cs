using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //behaviour of the bullets
    public bool isFire;
    public float timeBetweenBullets;
    public float attackSpeed;

    //bullets
    public GameObject bulletPrefab;
    public BulletController bullet;
    public Transform firePoint;
    
    void Update() {
        //shoot of left mouse button is held
        if (Input.GetMouseButtonDown(0)) {
           isFire = true;
        }
        
        //stop shooting if left mouse button is released
        if (Input.GetMouseButtonUp(0)) {
            isFire = false;
        }
        
        //fire the bullets only if you are not sprinting
        if (isFire && Input.GetKeyUp(KeyCode.LeftShift) == false) {
            attackSpeed -= Time.deltaTime;
            if (attackSpeed <= 0) {
                attackSpeed = timeBetweenBullets;
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
