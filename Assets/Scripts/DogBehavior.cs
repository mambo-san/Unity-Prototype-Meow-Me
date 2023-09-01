using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehavior : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    private GameObject target;
    Vector3 startPos = new Vector3(0, 0, 0);
    private float boundary = 25;
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        FindNewTarget();

        InvokeRepeating("FindNewTarget", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            FindNewTarget();
        }
        rb.transform.LookAt(target.transform);
        if (Vector3.Distance(startPos, transform.position) > boundary)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 0.1f);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(rb.transform.forward * speed, ForceMode.Acceleration);
    }
    void FindNewTarget()
    {
        //Prioritize cats
        if (target == null || target == player)
        {
            GameObject[] cat_list = GameObject.FindGameObjectsWithTag("Cat");
            if (cat_list.Length == 0)
            {
                target = player;
            }
            else
            {
                target = cat_list[Random.Range(0, cat_list.Length)];
            }
        }
    }
}
