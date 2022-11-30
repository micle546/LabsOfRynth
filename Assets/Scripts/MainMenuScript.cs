﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loadingScreen;
    public GameObject optionsMenu;
    public Slider loadingbar;
    public TextMeshProUGUI loadingText;

    public void Start()
    {
        mainMenu.SetActive(true);
        loadingScreen.SetActive(false);
        optionsMenu.SetActive(false);
    }
    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        Debug.Log("Loading Scene: " + SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);

        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync(nextSceneIndex));
    }

    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            loadingbar.value = progress;
            loadingText.text = "Loading " + progress*100 + "%";

            yield return null;
        }


    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player quit game");
    }
}