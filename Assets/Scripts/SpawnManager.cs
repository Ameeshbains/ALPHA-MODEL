using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Here we are creating an array,so that we can add a bunch of prefabs into it for random spawn
    public GameObject[] CarrotPrefabs;
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;
    private float startDelay = 0.2f;
    private float spawnInterval = 0.5f;

    private RolexScript playerControllerScript;



    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("ROLEX").GetComponent<RolexScript>();

        //This will basically start the method SpawnRandomCarrot, and then delay the time of spawning,
        //With intervals in spawning
        InvokeRepeating("SpawnRandomCarrot", startDelay , spawnInterval);

    }




    // Update is called once per frame
    void Update()
    {




    }

    void SpawnRandomCarrot()
    {

        if (playerControllerScript.gameOver == false)
        {
            Debug.Log("Array Length: " + CarrotPrefabs.Length);

            //The Range method means that it will randomize from the first number we have and the last number we have  
            int carrotIndex = Random.Range(0, CarrotPrefabs.Length);

            Debug.Log("Carrot Index: " + carrotIndex);
            //This piece of code will give us a random spawn POS
            //We have this all clean code, since there is no hard code
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);




            Instantiate(CarrotPrefabs[carrotIndex], spawnPos, CarrotPrefabs[carrotIndex].transform.rotation);



        }






    }





}
