using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30;
    private float lowerBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //IN HERE WE ARE CRATING A RANGE IN WHICH THE GAMEOBJECT MUST BE DELETED 
        if(transform.position.z > topBound) 
        {

            Destroy(gameObject);


        }else if(transform.position.z < lowerBound)
        {

            Destroy(gameObject);


        }



        
    }
}
