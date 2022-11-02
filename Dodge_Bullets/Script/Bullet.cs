using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    public float speed = 6f;
    private Rigidbody bulletRig;

    void Start()
    {
        player = GameObject.Find("Player");
        bulletRig = GetComponent<Rigidbody>();
        bulletRig.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

    //        if (playerHealth != null)
    //        {
    //            playerHealth.Damage(100);
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().Damage(100);
            Destroy(gameObject);
        }
    }
}
