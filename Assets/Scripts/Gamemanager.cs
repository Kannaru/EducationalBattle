using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    //game status
    public bool gameActive = true;
    public bool bossInGame;

    //UI classes before the game
    public Canvas MainMenu;
    public Button StartButton;

    //UI classes after the game
    public Canvas GameOverCanvas;
    public Button RestartButton;

    //UI classes for entire game
    public Canvas inGameCanvas;
    public Text healthText;
    public Text bossHealthText;
    public Text ScoreText;


    //prefab to spawn boss
    public GameObject boss;

    //audiosource
    public bool playaudio;
    public AudioSource source;

    //health for player and enemy
    public int health;
    public int bosshealth;

    //floats for the score
    public float score;
    public float roundedscore;
    private float _decreaseAmount = 80;

    void Start()
    {
        //make hp reset each time you restart
        health = 5;
        bosshealth = 100;
        score = 10000;
        //get source to play the audio
        source = GetComponent<AudioSource>();
        StartButton.onClick.AddListener(StartGame);
    }


    void Update()
    {
        DecreaseScore();
        updateHealths();

        if (bosshealth <= 0) {
            finishgamescreen();
        }

        if (health == 0) {
            finishgamescreen();
        }
    }

    public void StartGame()
    {
        MainMenu.gameObject.SetActive(false);
        Instantiate(boss, new Vector3(0, 30, 200), Quaternion.identity);
        inGameCanvas.gameObject.SetActive(true);

        bossInGame = true;
    }

    public void DecreaseScore()
    {
        if (bossInGame) {
            score -= _decreaseAmount * Time.deltaTime;
            roundedscore = Mathf.Round(score);
            ScoreText.GetComponent<Text>().text = "Score: " + roundedscore;
        }
    }

    public void updateHealths()
    {
        healthText.GetComponent<Text>().text = "Your hp: " + health;
        bossHealthText.GetComponent<Text>().text = "Boss hp: " + bosshealth;
    }

    public void finishgamescreen()
    {
        gameActive = false;
        bossInGame = false;
        if (bosshealth == 0 && ! playaudio) {
            source.Play();
            playaudio = true;
        }

        inGameCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(true);
    }
}