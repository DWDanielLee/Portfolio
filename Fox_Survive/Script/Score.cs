using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score = 0;
    Text mytext;
    // Start is called before the first frame update
    void Start()
    {
        mytext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mytext.text = "Score: " + score;

        if (score >= 1000)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
