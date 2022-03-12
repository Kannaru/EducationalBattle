using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackPlayer1 : MonoBehaviour
{ 
    public GameObject Bullets;
    private enemyBulletControllerAttack1 Control;

    public Transform Shootingpoint;
    
    public GameObject Bullet;
        
    public bool attack1;
    public float fireRateAttack1;
    public float nextFireAttack1;
    
    public bool attack2;
    public float fireRateAttack2;
    public float nextFireAttack2;
    
    public bool attack3;
    public float fireRateAttack3;
    public float nextFireAttack3;
    private float attack3Axis;
    private Vector3 randomSpawnLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        Control = Bullets.GetComponent<enemyBulletControllerAttack1>();
        fireRateAttack1 = 1f;
        nextFireAttack1 = Time.time;   
        fireRateAttack2 = 0.3f;
        nextFireAttack2 = Time.time;
        fireRateAttack3 = 0.3f;
        nextFireAttack3 = Time.time;
        attack1 = false;
        attack2 = false;
        attack3 = false;
    }
    

    // Update is called once per frame
    void Update()
    {   
        checkIfTimeToFire ();
        attack3Axis = UnityEngine.Random.Range(-300, 300);
        randomSpawnLocation = new Vector3(attack3Axis, 7, -300);
    }

    void checkIfTimeToFire ()
    {
        if (Time.time > nextFireAttack1 && attack1)
        {
            attack2 = false;
            attack3 = false;
            Instantiate(Bullet, Shootingpoint.position, Quaternion.identity);
            Control.AimX = 100;
            Instantiate(Bullet, Shootingpoint.position, Quaternion.identity);
            Control.AimX = 50;
            Instantiate(Bullet, Shootingpoint.position, Quaternion.identity);
            Control.AimX = -50;
            Instantiate(Bullet, Shootingpoint.position, Quaternion.identity);
            Control.AimX = -100;
            Instantiate(Bullet, Shootingpoint.position, Quaternion.identity);
            Control.AimX = 0;
            Control.Attack1Active();

            nextFireAttack1 = Time.time + fireRateAttack1;
        }
        else if (Time.time > nextFireAttack2 && attack2)
        {
            attack1 = false;
            attack3 = false;
            Instantiate(Bullet, Shootingpoint.position, Quaternion.identity);
            nextFireAttack2 = Time.time + fireRateAttack2;
            Control.Attack2Active();
        }   else if (Time.time > nextFireAttack3 && attack3)
        {
            attack1 = false;
            attack2 = false;
            Instantiate(Bullet, randomSpawnLocation, Quaternion.identity);
            nextFireAttack3 = Time.time + fireRateAttack3;
            Control.Attack3Active();
        }
    }
}
