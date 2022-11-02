using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossEnemyHealth : MonoBehaviour
{
    int hp = 1500;
    public RawImage imgBar;

    public AudioClip clipHurt;
    public AudioClip clipDeath;

    public void Damage(int amount)
    {
        if (hp <= 0)
            return;
        hp -= amount;
        imgBar.transform.localScale = new Vector3(hp / 1500.0f, 1, 1);
        GetComponent<AudioSource>().PlayOneShot(clipHurt);

        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnemyMoveFollow>().enabled = false;

            Destroy(gameObject, 2);
            GameObject.Find("GameManager").GetComponent<BossEnemySpawn>().count--;
            GetComponent<AudioSource>().PlayOneShot(clipDeath);

            SceneManager.LoadScene("WinScene");
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
