using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    float time;
    bool bInrange;
    public AudioClip clipAttack;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bInrange = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            bInrange = true;
            GetComponent<Animator>().SetBool("bIsAttacking", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            bInrange = false;
            GetComponent<Animator>().SetBool("bIsAttacking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 1.5f && bInrange)
        {
            time = 0;

            player.GetComponent<PlayerHealth>().Damage(20);

            GetComponent<AudioSource>().PlayOneShot(clipAttack);
        }

        if(player.GetComponent<PlayerHealth>().hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("PlayerDeath");
            bInrange = false;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("PlayerRespawn");
        }
    }
}
