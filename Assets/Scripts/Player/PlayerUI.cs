using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance { get; private set; }

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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
        UpdateHealthUI();
    }

    public void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
        if (currentHealth == 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(4);
        }
    }


    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
    public void togglePause()
    {
        setPaused(!isPaused);
    }

    public void setPaused(bool value)
    {
        isPaused = value;
        pauseMenu.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
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
        //Debug.Log(currentHealth);
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

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            setPaused(true);


    }

}
