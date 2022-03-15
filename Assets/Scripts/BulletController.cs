using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 400;
    // Start is called before the first frame update
    public void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    public void OnCollisionEnter(Collision collision)
    { 
        //maybe fout
        Gamemanager gm = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.bosshealth -= 1;
            Destroy(gameObject);
        }

    }
}
