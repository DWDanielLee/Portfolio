using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    LineRenderer line;
    Transform shootPoint;

    public AudioClip clipGunShot;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        shootPoint = transform.Find("ShootPoint");
    }

    void Shoot()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
            if (e != null)
            {
                e.Damage(50);
                Score.score += 10;
            }

            BossEnemyHealth eB = hit.collider.GetComponent<BossEnemyHealth>();
            if (eB != null)
            {
                eB.Damage(50);
                Score.score += 10;
            }

            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1, shootPoint.position + ray.direction * 10);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (CrossPlatformInputManager.GetButton("Fire1") //|| Input.GetKey(KeyCode.LeftControl)
            && timer >= 0.2f)
        {
            //Debug.Log("shoot");
            Shoot();
            timer = 0;
            GetComponent<AudioSource>().PlayOneShot(clipGunShot);
            GetComponent<Light>().enabled = true;
            
        }

        if(timer > 0.05f)
        {
            line.enabled = false;
            GetComponent<Light>().enabled = false;
        }
    }
    
}
