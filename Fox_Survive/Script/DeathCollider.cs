using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    GameObject player;
    //bool bInrange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //bInrange = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
           // bInrange = true;
            player.GetComponent<PlayerHealth>().Damage(100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().hp <= 0)
        {
           // bInrange = false;
        }
    }
}
