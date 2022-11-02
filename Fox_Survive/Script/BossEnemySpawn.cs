using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySpawn : MonoBehaviour
{
    public GameObject Boss;
    public Transform point;
    public float time;
    public int max;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBoss", time, time);
    }

    void CreateBoss()
    {
        if (count >= max)
        {
            return;
        }

        count++;
        Instantiate(Boss, point);
        Debug.Log("Boss Enemy Appeared");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
