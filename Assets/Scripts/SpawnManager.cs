using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float spawnStart = 2f;
    private float spawnDelay = 2f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //set player controller script equal to the actual player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //create repeating spawner
        InvokeRepeating("SpawnObstacle", spawnStart, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create method to spawn obstacles
    void SpawnObstacle()
    {
        //if statement to check if game is over
        if(playerControllerScript.gameOver == false)
        {

            //spawn random number between prefabs
           int ranNum = Random.Range(0, obstaclPrefab.Length);
            //spawn obstacle prefabs
            Instantiate(obstaclPrefab[ranNum], spawnPos, obstaclPrefab[ranNum].transform.rotation);
        }
       
    }
}
