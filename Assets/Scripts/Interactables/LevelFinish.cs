using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelFinish : Interactable
{
    public GameObject loadingScreen;
    public Slider loadingbar;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        loadingScreen.SetActive(false);

    }

    protected override void Interact()
    {
        PlayerUI.instance.setPaused(true);
        loadingScreen.SetActive(true);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        Debug.Log("Loading Scene: " + SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        StartCoroutine(LoadAsync(nextSceneIndex));
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            loadingbar.value = progress;
            loadingText.text = "Loading " + Mathf.Round(progress * 100) + "%";

            yield return null;
        }


    }

}
