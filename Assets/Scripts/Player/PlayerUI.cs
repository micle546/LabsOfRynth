using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private GameObject pauseMenu;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
    }

    public void Update()
    {
        
    }


    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
    public void togglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        //TODO add pause functionality
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
