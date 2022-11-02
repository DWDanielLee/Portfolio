using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //bool isPause;

    public void PauseButton()
    {
        GameObject.Find("HUD").transform.Find("PauseMenu").gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        GameObject.Find("HUD").transform.Find("PauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    // Start is called before the first frame update
    void Start()
    {
        //isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isPause == false)
        //{
        //    Time.timeScale = 0;
        //    Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //    isPause = true;
        //    return;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //    Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //    isPause = false;
        //    return;
        //}
    }
}
