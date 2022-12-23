using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    Vector3 temppos;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;
        temppos= transform.position;
        temppos.x= player.position.x;
        transform.position= temppos;
    }
    
}
