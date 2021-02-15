using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public GameObject objectToFollow; 
    public float height;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow == null)
        {
            return;
        }

        Vector3 objectLocation = objectToFollow.transform.position;
        objectLocation.y += height;

        transform.position = objectLocation;
    }
}
