using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;

    Vector3 posRespawn;

    //public bool bInvincible;

    bool bDamage;
    public RawImage imgDamage;
    public RawImage imgBar;
    public Slider sliderHP;

    public AudioClip clipHurt;
    public AudioClip clipDeath;
    public int LivesCount;
    public void SetHP(int value)
    {
        if (value < 0 || value > 100)
            return;
        hp = value;

        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1);
        sliderHP.value = hp;
    }
    public void Damage(int amount)
    {
        if (hp <= 0)
            return;

        hp -= amount;
        bDamage = true;
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1);

        sliderHP.value = hp;
        GetComponent<AudioSource>().PlayOneShot(clipHurt);

        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");

            GetComponent<PlayerMove>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;

            GetComponent<AudioSource>().PlayOneShot(clipDeath);

            Invoke("Respawn", 3);
            LivesCount--;
            Lives.lives -= 1;

            if (LivesCount == 0)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    public void Respawn()
    {
        hp = 100;

        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");

        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;

        imgBar.transform.localScale = new Vector3(1, 1, 1);
        sliderHP.value = hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        LivesCount = 3;
        posRespawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bDamage)
        {
            imgDamage.color = new Color(0.5568628f, 0.221239f, 0.04313724f, 1);
        }
        else
        {
            imgDamage.color = Color.Lerp(imgDamage.color, Color.clear, 2 * Time.deltaTime);
        }

        bDamage = false;
    }
}
