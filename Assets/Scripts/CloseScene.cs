using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseScene : MonoBehaviour
{
    public static event Action DisposeScene;
    public void OnBtnClick(int sceneToLoad)
    {
        if (sceneToLoad < 0) Application.Quit();
        else
            SceneManager.LoadScene(sceneToLoad);
        DisposeScene?.Invoke();
    }
}
