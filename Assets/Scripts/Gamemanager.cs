using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //game status
    public bool gameActive = true;
    public bool bossInGame;

    //UI classes before the game
    public Canvas mainMenu;
    public Button startButton;
    
    public Canvas gameOverCanvas;

    //UI classes for entire game
    public Canvas inGameCanvas;
    public Text healthText;
    public Text bossHealthText;
    public Text scoreText;


    //prefab to spawn boss
    public GameObject boss;

    //audio source
    public bool playAudio;
    public AudioSource source;

    //health for player and enemy
    public int health;
    public int bossHealth;

    //floats for the score
    public float score;
    public float roundedScore;
    private const float DecreaseAmount = 80;

    private void Start()
    {
        //make hp reset each time you restart
        health = 5;
        bossHealth = 100;
        score = 10000;
        //get source to play the audio
        source = GetComponent<AudioSource>();
        startButton.onClick.AddListener(StartGame);
    }


    private void Update()
    {
        DecreaseScore();
        UpdateHealths();

        //game over statements
        if (bossHealth <= 0) {
            FinishGameScreen();
        }

        if (health == 0) {
            FinishGameScreen();
        }
    }

    private void StartGame()
    {
        mainMenu.gameObject.SetActive(false);
        Instantiate(boss, new Vector3(0, 30, 200), Quaternion.identity);
        inGameCanvas.gameObject.SetActive(true);
        bossInGame = true;
    }

    private void DecreaseScore()
    {
        if (bossInGame) {
            score -= DecreaseAmount * Time.deltaTime;
            roundedScore = Mathf.Round(score);
            if (roundedScore < 0) {
                roundedScore = 0;
            }
            scoreText.GetComponent<Text>().text = "Score: " + roundedScore;
           
        }
    }

    private void UpdateHealths()
    {
        healthText.GetComponent<Text>().text = "Your hp: " + health;
        bossHealthText.GetComponent<Text>().text = "Boss hp: " + bossHealth;
    }

    private void FinishGameScreen()
    {
        gameActive = false;
        bossInGame = false;
        if (bossHealth == 0 && ! playAudio) {
            source.Play();
            playAudio = true;
        }
        //HUD of game turn off and HUD of game over on
        inGameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }
}