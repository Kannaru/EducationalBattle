using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(refreshGame);
    }
    
    void refreshGame()
    {
        //if the button is pressed reset the entire scene, restarting the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
