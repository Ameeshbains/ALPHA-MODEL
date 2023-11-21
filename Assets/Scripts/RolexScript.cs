using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolexScript : MonoBehaviour
{
    //This is for the horizontal input
    public float horizontalInput;
    //public float verticalInput;
    private Animator playerAnim;
    public float speed = 15.0f;
    public float xRange = 11.0f;
    public ParticleSystem explosionParticle;
    public bool gameOver;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool hasPowerUp = false;
    

    private Rigidbody playerRB;         //This initialization of the rigidbody

    public float jumpForce = 10;        //Jumpforce of  player
    public float gravityModifier;       //Modifying the gravity
    public bool isOnGround = true;

    //public float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        
        //These are refernces before we can use them
        //1. rigidbody for applying physics to the game
        playerRB = GetComponent<Rigidbody>();

        //2. This is for the aniamtion for game
        playerAnim = GetComponent<Animator>();

        //3. THis is for the audio of the game
        playerAudio = GetComponent<AudioSource>();

       



        Physics.gravity *= gravityModifier;  //We are getting all the physics of the game, and we are 
                                             //A short form of saying "Physics.gravity = gravityModifier * Physics.gravity "

    }

    // Update is called once per frame
    void Update()
    {
        //We have to prevent the player from going off the side of the screen with an if-then statement.
        if (transform.position.x < -xRange)
        {

            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);


        }
        //We have to prevent the player from going off the side of the screen with an if-then statement.
        if (transform.position.x > xRange)
        {

            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);


        }

        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        //This code is used to make the character (ROLEX) go left and right.
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


        //This code is basically saying that if we press the key "SPACE" the player will jump up
        //Also, it will not allow us to double jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {

            //ForceMode.Inpulse will immediately add force that we want to apply
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);       //JUMP SOUNDS  
                                                            //The player audio will play in one go hence the name "One Shot" for jumpsounds



        }

        

    }

    //This is for when the player collides with the objects
    private void OnCollisionEnter(Collision collision)
    {


        //IF the player collides with the ground tag then set the isOnground to true. Therefore, 
        //It is used to determine if the player  is on the ground or not 

        //We have a bunch of else if statements. That explains that if the player collides
        //with the prefab / obstacle / veg then a bunch of code will be executed, such as 
        //1. the game will say "Game over"
        //2. the game will stop playing!
        //3. THe animation of the character dying will pllay since we end the game by colliding with the obtacle / veg
        //4. Also, The animation for explosion will play.
        //5. Here we are saying that if the player collides with the obtacle / veg then play crash sound
        

        if(collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

        }else if (collision.gameObject.CompareTag("Obstacle1"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            // ROLEX.gameObject.GetComponent<RolexScript>().enabled = false;
            Destroy(collision.gameObject);



        }
        else if (collision.gameObject.CompareTag("Obstacle2"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Obstacle3"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstacle4"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("VEG1"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("VEG2"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("VEG3"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("VEG4"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("VEG5"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("VEG6"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("VEG7"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("VEG8"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }






    }


    //This method is used to destroy the powerup object when collideed with
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("POWERUP"))
        {

            hasPowerUp = true;
            Destroy(other.gameObject);

        }


    }



}
