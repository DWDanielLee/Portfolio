using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject[] Cop;
    public float timeValue = 90f;
    int state = 0;

    [SerializeField] Text timerText;

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 45f && state == 0)
        {
            state = 1;
            Cop[0].SetActive(true);
        }

        if (timeToDisplay < 30f && state == 1)
        {
            state = 2;
            Cop[1].SetActive(true);
        }

        if (timeToDisplay < 15f && state == 2)
        {
            state = 3;
            Cop[2].SetActive(true);
        }

        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            SceneManager.LoadScene(3);
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
