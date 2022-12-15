using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private TextMeshProUGUI healthText;

    private bool isPaused = false;
    private float currentHealth = 100f;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    private float lerpTimer;

    public Image frontHealthBar;
    public Image backHealthBar;
    

    public void Start()
    {
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        UpdateHealthUI();
    }

    public void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
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
    private void UpdateHealthUI()
    {
        Debug.Log(currentHealth);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = currentHealth / maxHealth;
        healthText.SetText("Health: " + currentHealth + "/" + maxHealth);

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        lerpTimer = 0f;
        //TODO: trigger audio effect
    }
    public void RestoreHealth(float healAmount)
    {
        currentHealth += healAmount;
        lerpTimer = 0f;
        //TODO: trigger audio effect?
    }
}
