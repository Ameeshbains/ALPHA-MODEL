using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolexScript : MonoBehaviour
{
    //This is for the horizontal input
    public float horizontalInput;
    //This is for the vertical input
    public float verticalInput;
    //This is for the speed 
    public float speed = 15.0f;
    //The range in which the player can move
    public float xRange = 15.0f;
    public float zRange = 15.0f;
    public float zForwardRange = 15.0f;
    //This is for gameOver 
    public bool gameOver;
    //This is for the audio sounds in game, such as crash and jump
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    //This is for powerup
    public bool hasPowerUp = false;
    //For the strength fo the powerup
    private float powerupStrength = 15.0f;
    //This is the powerup indicator
    public GameObject powerupIndicator;
    //This is for the audio of the background
    public AudioSource[] audios;


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

        //2. This is for referencing the audi for the main camera, so that we can use it to play or pause
        audios = FindObjectsOfType<AudioSource>();

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


        //We have to prevent the player from going off the front of the screen with an if-then statement.
        if (transform.position.z < -zForwardRange)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, -zForwardRange);


        }
        //We have to prevent the player from going off the backwards of the screen with an if-then statement.
        if (transform.position.z > zRange)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);


        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        //This code is used to make the character (ROLEX) go left and right.
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


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


        powerupIndicator.transform.position = transform.position;


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
        //3. Crassh sound will play
        //4. The backgrund song will stop playing
        //4. Here we are saying that if the player collides with the obstacle  then play crash sound
        //5. The speed is used to stop the player from moving
        

        if(collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

        }
        else if (collision.gameObject.CompareTag("VEG1"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
            Destroy(collision.gameObject);


            speed = 0;

           
            


        }
        else if (collision.gameObject.CompareTag("VEG2"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
            Destroy(collision.gameObject);
            speed = 0;



        }
        else if (collision.gameObject.CompareTag("VEG3"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
            Destroy(collision.gameObject);
            speed = 0;

        }
        else if (collision.gameObject.CompareTag("VEG4"))
        {

            Debug.Log("GAME OVER!");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            
            foreach(AudioSource a in audios)
            {
                a.Pause();
            }
            Destroy(collision.gameObject);
            speed = 0;


        }
        






    }//END OF ONCOLLISION ENTER METHOD






    //////////////
    // POWER UP //
    //////////////

    //This method is used to destroy the powerup object when collideed with
    //Also, the powerup will be enabled
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("POWERUP"))
        {

            hasPowerUp = true;

            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
        
            StartCoroutine(PowerupCountdownRoutine());

        }





    }//END OF ONTRIGGERENTER METHOD




    //This is used to reset the player back to the original state when finishing the power up
    IEnumerator PowerupCountdownRoutine()
    {

        yield return new WaitForSeconds(7);                 
        powerupIndicator.gameObject.SetActive(false);
        hasPowerUp = false;

    }//END OF IENUMERATOR METHOD



    //THIS WILL
    //IF YOU CLASH WITH GAMEOBJECT AND HAVE POWERUP  
    //THEN PUSH ENEMY AWAY FROM YOU
    private void onCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("VEG1") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);


            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("VEG2") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;


            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("VEG3") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);


            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("VEG4") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);


            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }


    }



}
