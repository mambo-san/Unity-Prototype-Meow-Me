using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowEffect : MonoBehaviour
{
    private Rigidbody parentRb;
    private float maxRadius = 5;
    private Vector3 meowGrowSpeed = new Vector3(15f, 15f, 15f);
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < maxRadius)
        {
            transform.localScale += meowGrowSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void setMaxRadius(float newMaxRadius)
    {
        maxRadius = newMaxRadius;
    }


}
