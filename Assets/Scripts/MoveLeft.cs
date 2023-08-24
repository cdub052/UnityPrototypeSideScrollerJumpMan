using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        //set player controller script equal to the actual player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if statement to check player controller to see if player has hit an obstacle
        if (playerControllerScript.gameOver == false)
        {
            // move object left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //if statement to check and destroy obstacles if exits bounds and tag equals obstacle
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
