using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    private GameObject player;
    Rigidbody catRb;
    Vector3 playerPosOffset = new Vector3(0, 0, - 2);
    Vector3 startPos = new Vector3(0, 0, 0);
    public bool isFriend = false;
    public float speed = 1.5f;
    private float boundary = 25;
    private int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
        catRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.gameObject.transform);
        
        

        


    }

    private void FixedUpdate()
    {
        var qTo = Quaternion.LookRotation(player.transform.position - transform.position);

        qTo = Quaternion.Slerp(transform.rotation, qTo, 100 * Time.deltaTime);
        catRb.MoveRotation(qTo);
        if (isFriend)
        {
            walkBehindPlayer();
        }
    }

    private void LateUpdate()
    {
        //Boundary check
        if (Vector3.Distance(startPos, transform.position) > boundary)
        {
            Debug.Log("Reached boundary");
            transform.position = Vector3.MoveTowards(transform.position, startPos, 0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Dog"))
        {
            health--;
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MeowEffect"))
        {
            isFriend = true;
            Debug.Log("Became friend");
        }
    }

    private void walkBehindPlayer(){
        catRb.AddForce(catRb.transform.forward * speed, ForceMode.Acceleration);
    }
}
