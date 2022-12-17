using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnToMenu()
    {
        //PlayerUI.instance.setPaused(true);
        int nextSceneIndex = 0;

        Debug.Log("Loading Scene: " + SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
