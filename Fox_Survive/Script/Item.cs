using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip clipHeart;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ItemHeart")
        {
            GetComponent<AudioSource>().PlayOneShot(clipHeart);

            GetComponent<PlayerHealth>().SetHP(100);
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
