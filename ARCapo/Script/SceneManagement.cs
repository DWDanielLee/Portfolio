using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject CautionBG;
    public static GameObject Instruction;
    public void SceneExit()
    {
        Application.Quit();
    }

    public void CapoYoutubeURL()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC5qtzPDbg9pFc51EL4YmNgA");
    }

    public void CapoFacebookURL()
    {
        Application.OpenURL("https://www.facebook.com/ajou.capo");
    }

    public void CapoInstagramURL()
    {
        Application.OpenURL("https://www.instagram.com/ajou_capo/");
    }

    public void CautionOnOff()
    {
        CautionBG.SetActive(false);
        Instruction.SetActive(true);
    }
    void Start()
    {
        CautionBG = GameObject.Find("CautionBackground");
        Instruction = GameObject.Find("Canvas").transform.Find("Instruction").gameObject;
    }

}
