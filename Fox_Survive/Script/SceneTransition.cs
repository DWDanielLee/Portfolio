using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadPause()
    {
        Time.timeScale = 0f;
    }
    public void LoadContinue()
    {
        Time.timeScale = 1f;
    }

    public void LoadExit()
    { 
        Application.Quit();
    }
}