using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce;
    private float gravityModifier = 1.8f;
    private Rigidbody playerRb;
    private float topBound = 15f;
    private float bottomBound = 0f;
    

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {

        //get players rigid body component
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && topBound > playerRb.transform.position.y)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        //if statement to stop player from going to high
        if(playerRb.transform.position.y > topBound)
        {
            //keep player from going to high
            playerRb.transform.position = new Vector3(playerRb.transform.position.x, topBound, playerRb.transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            explosionParticle.Play();

        } 



        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            
        }

        //if player collides with the ground make player bounce
        if (other.gameObject.CompareTag("Ground"))
        {
            //make player bounce after touching the ground
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            //play audio clip
            playerAudio.PlayOneShot(bounceSound, 1.0f);

        }

    }
   

}
