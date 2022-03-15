using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackPlayer1 : MonoBehaviour
{ 
    public GameObject bullets;
    private enemyBulletControllerAttack1 _control;

    public Transform shootingPoint;
    
    public GameObject bullet;
        
    public bool attack1;
    public float fireRateAttack1;
    public float nextFireAttack1;
    
    public bool attack2;
    public float fireRateAttack2;
    public float nextFireAttack2;
    
    public bool attack3;
    public float fireRateAttack3;
    public float nextFireAttack3;
    private float _attack3Axis;
    private Vector3 _randomSpawnLocation;
    

    void Start()
    {
        _control = bullets.GetComponent<enemyBulletControllerAttack1>();
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
    
    void Update()
    {   
        CheckIfTimeToFire ();
        _attack3Axis = UnityEngine.Random.Range(-300, 300);
        _randomSpawnLocation = new Vector3(_attack3Axis, 7, -300);
    }

    private void CheckIfTimeToFire ()
    {
        if (Time.time > nextFireAttack1 && attack1)
        {
            attack2 = false;
            attack3 = false;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = 100;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = 50;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = -50;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = -100;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = 0;
            _control.Attack1Active();

            nextFireAttack1 = Time.time + fireRateAttack1;
        }
        else if (Time.time > nextFireAttack2 && attack2)
        {
            attack1 = false;
            attack3 = false;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            nextFireAttack2 = Time.time + fireRateAttack2;
            _control.Attack2Active();
        }   else if (Time.time > nextFireAttack3 && attack3)
        {
            attack1 = false;
            attack2 = false;
            Instantiate(bullet, _randomSpawnLocation, Quaternion.identity);
            nextFireAttack3 = Time.time + fireRateAttack3;
            _control.Attack3Active();
        }
    }
}
