using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0.0f, 5.75f, -9.5f);
    private Space offsetPositionSpace = Space.Self;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.localPosition = player.transform.localPosition + offset;
        //transform.rotation = player.transform.rotation;
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            transform.position = player.position + offset;
        }

        transform.LookAt(player);
    }
}
