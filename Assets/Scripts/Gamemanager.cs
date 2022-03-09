using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public bool gameActive = true;
    public bool bossInGame;
    
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn in the enemy
        if (gameActive && bossInGame == false)
        {
            Instantiate(Boss);
            bossInGame = true;
        }
    }
}
