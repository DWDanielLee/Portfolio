using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    public Text highscoreText;
    public GameObject gameoverUI;

    private int score = 0;
    private int highscore = 0;
    public GameObject isScoreScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore : ", 0);
        highscoreText.text = "Highscore : " + highscore.ToString();

    }

    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
            if(highscore < score)
            {
                PlayerPrefs.SetInt("Highscore : ", score);
            }
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("cutscene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ResethighscoreButton()
    {
        PlayerPrefs.DeleteKey("Highscore : ");
        isScoreScreen.gameObject.SetActive(true);
        Invoke("isScoreScreenOff", 3);
    }

    public void isScoreScreenOff()
    {
        isScoreScreen.gameObject.SetActive(false);
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.SetActive(false);
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }
}
