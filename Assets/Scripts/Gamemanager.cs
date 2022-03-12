using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public bool gameActive = true;
    public bool bossInGame;
    
    public GameObject Boss;

    public int health;
    public int Bosshealth;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        Bosshealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn in the enemy
        if (gameActive && bossInGame == false)
        {
            Instantiate(Boss, new Vector3(0,50,200), Quaternion.identity);
            bossInGame = true;
        }
    }
}
