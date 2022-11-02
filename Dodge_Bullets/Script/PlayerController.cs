using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRig;
    public float speed = 8f;



    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //float xinput = Input.GetAxis("Horizontal");
        //float zinput = Input.GetAxis("Vertical");

        float xinput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float zinput = CrossPlatformInputManager.GetAxisRaw("Vertical");

        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRig.velocity = newVelocity;
    }
}
