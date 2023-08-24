using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackround : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //set start variable equal to starting position
       startPos = transform.position;
        //set repeatWidth to half of the box collider with get collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if statement to make backround check if backround has moved half way and reset it
        if (transform.position.x < startPos.x - repeatWidth)
        {
            //reset start position
            transform.position = startPos;
        }
    }
}
