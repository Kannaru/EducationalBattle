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
    private AudioSource source;
    public GameObject bulletPrefab;
    public BulletController bullet;
    public Transform firePoint;


    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Gamemanager gm = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        //shoot if spacebar is held
        if (Input.GetKeyDown(KeyCode.Space) && gm.gameActive) {
            isFire = true;
        }

        //stop shooting if left mouse button is released
        if (Input.GetKeyUp(KeyCode.Space)) {
            isFire = false;
        }

        //fire the bullets
        if (isFire) {
            attackSpeed -= Time.deltaTime;
            if (attackSpeed <= 0) {
                attackSpeed = timeBetweenBullets;
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                source.Play();
            }
        }
    }
}