using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public SceneManager num;

    public void LoadIntroScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadExit()
    {
        Application.Quit();
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
    }

    public void PauseButton()
    {
        GameObject.Find("HUD").transform.Find("PausedMenu").gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        GameObject.Find("HUD").transform.Find("PausedMenu").gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
    }
}
