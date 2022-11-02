using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] point;

    public int max;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", 15, 15);
    }

    void Create()
    {
        if (count >= max)
        {
            return;
        }

        count++;
        int i = Random.Range(0, point.Length);
        Instantiate(prefab, point[i]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
