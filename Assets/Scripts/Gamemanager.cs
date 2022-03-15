using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    //game status
    public bool gameActive = true;
    public bool bossInGame;
    
    //prefab to spawn boss
    public GameObject Boss;

    //health for player and enemy
    public int health;
    public int bosshealth;
    
    void Start()
    {
        //make hp reset each time you restart
        health = 5;
        bosshealth = 20;
    }


    void Update()
    { 
        // Spawn in the enemy
        SpawnBossWhenGameStart();
    }

    public void SpawnBossWhenGameStart()
    {
        if (gameActive && bossInGame == false)
        {
            Instantiate(Boss, new Vector3(0,50,200), Quaternion.identity);
            bossInGame = true;
        }
    }
}
