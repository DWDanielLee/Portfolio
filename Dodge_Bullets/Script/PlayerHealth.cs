using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody rig;
    public int hp = 100;
    Vector3 posRespawn;
    public AudioClip clipDeath;
    int Lifecount;
    //public float blink;
    //public float immuned;
    //public Renderer modelRenderer1;
    //public Renderer modelRenderer2;
    //private float blinkTime = 0.1f;
    //private float immunedTime;
    //Vector3 rotRespawn;

    void Start()
    {
        Lifecount = 3;
        posRespawn = transform.position;
        //rotRespawn = transform.eulerAngles;
        rig = GetComponent<Rigidbody>();
        rig.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
    }
    public void Damage(int amount)
    {
        if (hp <= 0)
            return;

        hp -= amount;
        if (hp <= 0)
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(clipDeath);
            rig.constraints = RigidbodyConstraints.FreezePositionY;
            Lifecount--;
            LifeCount.life -= 1;
            if (Lifecount == 0)
            {
                SceneManager.LoadScene(2);
            }
            Invoke("Respawn", 3);
        }
    }

    public void Respawn()
    {
        hp = 100;

        transform.position = posRespawn;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rig.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
    RigidbodyConstraints.FreezeRotationZ;
        GetComponent<PlayerController>().enabled = true;
        //Invoke("EnableBlink", 0f);
        //Invoke("DisableBlink", 0.1f);
    }

    //private void EnableBlink()
    //{
    //    blink.SetActive(true);
    //}

    //private void DisableBlink()
    //{
    //    blink.SetActive(false);
    //}

}
