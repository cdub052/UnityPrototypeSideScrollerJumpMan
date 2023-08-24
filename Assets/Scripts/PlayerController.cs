using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //get ridgid body reference
    private Rigidbody playerRb;
    //get player animation reference
    private Animator playerAnim;
    //get player partical explosion
    public ParticleSystem explosionParticle;
    //get dirt partical animation
    public ParticleSystem dirtParticle;
    //get jump sound
    public AudioClip jumpSound;
    //get crash sound
    public AudioClip crashSound;
    //get player Audio source to play sounds
    public AudioSource playerAudio;
    //gravity modifiyer variable
    public float gravityModifier;
    public float jumpForce = 10;
    public bool isOnGround = true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        //assign player rigidbody variable to rigid body component using get component
        playerRb = GetComponent<Rigidbody>();
        //assign animation variable to the animator by getting the component
        playerAnim = GetComponent<Animator>();
        //get gravity by getting the physics
        Physics.gravity *= gravityModifier;
        //get player audio to play audio clips
        playerAudio = GetComponent<AudioSource>();

        gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //get force if player presses space and is on ground and game is not over
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //add force to player
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            //make player jump by calling the animator variable and getting the jump animation
            playerAnim.SetTrigger("Jump_trig");

            //make dirt particle stop on jump
            dirtParticle.Stop();

            //play audio on jump 
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    //method to check collision to see if player is on ground
    private void OnCollisionEnter(Collision collision)
    {

        //if statement to check if player is colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //make dirt particle play when on ground
            dirtParticle.Play();
        }
        //else if statement to check if player is colliding with obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //show game over and set it to true
            Debug.Log("Game Over");
            gameOver = true;

            //activate death animation by setting the animation bool to true and choosing first death animation 
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            //play explosion animation on collision
            explosionParticle.Play();
            //make dirt particle stop on game over
            dirtParticle.Stop();
            //play crash sound on collision
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
