using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject MeowEffect;

    private Vector3 startPos = Vector3.zero;
    
    private float boundary = 25;
    private float rotateSpeed = 200.0f;
    private float moveSpeed;
    private float walkSpeed = 3.0f;
    private float runSpeed = 10f;
    private float meowRadius = 5;
    private bool isRunning = true;

    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        playerRb = GetComponent<Rigidbody>();
        moveSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ToggleRunning();

        //Meow mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Meow();
        }


    }

    //Move the Player within radius based boundary
    void MovePlayer()
    {
        //Control Input
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Boundary check
        if (Vector3.Distance(startPos, transform.position) > boundary)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 0.1f);
        }
        else
        {
            //Player Control
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontalInput);
        }
    }

    // Change the movement speed
    void ToggleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isRunning)
            {
                moveSpeed = walkSpeed;
                isRunning = false;
            }
            else
            {
                moveSpeed = runSpeed;
                isRunning = true;
            }
        }
    }

    void Meow()
    {
        GameObject MeowVisualEffect = Instantiate(MeowEffect, transform.position,transform.rotation);
        MeowEffect meowEffectScript = MeowVisualEffect.GetComponent<MeowEffect>();
        meowEffectScript.setMaxRadius(meowRadius);
    }

    public void increaseMeowRadius(float increaseBy)
    {
        meowRadius += increaseBy;
    }
}
