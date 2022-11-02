using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    Transform patrol1, patrol2;
    NavMeshAgent nav;
    Vector3 posReturn;

    public float maxDistance = 6;
    public float minDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        //patrol1 = GameObject.Find("Patpos1").transform;
        //patrol2 = GameObject.Find("Patpos2").transform;
        //nav = GetComponent<NavMeshAgent>();
        //posReturn = transform.position;

        //GetComponent<Animator>().SetTrigger("PlayerDeath");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
