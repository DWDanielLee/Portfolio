using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public static int life = 3;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "LIFE: " + life;
    }
}
