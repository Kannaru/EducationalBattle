using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackPlayer : MonoBehaviour
{
    public GameObject Bullet;
    public float fireRate;

    public float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfTimeToFire ();

    }

    void checkIfTimeToFire ()
    {
        if (Time.time > nextFire)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            
            nextFire = Time.time + fireRate;
        }
    }
}
