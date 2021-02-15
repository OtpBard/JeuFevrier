using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public GameObject[] gameObjectColorChange;
    public float colorChangeDuration;
    [ColorUsage(true, true)]
    public Color newColor;
    [ColorUsage(true, true)]
    public Color baseColor;
    public float velocityThreshHold;
    private bool soundPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > velocityThreshHold)
        {
            foreach(GameObject go in gameObjectColorChange)
            {
                go.GetComponent<Renderer>().material.SetColor("_EmissionColor", newColor);
            }
            if(!soundPlay)
            {
                GetComponent<AudioSource>().Play();
                soundPlay = true;
            }
           
        }
        else
        {
            foreach(GameObject go in gameObjectColorChange)
            {
                go.GetComponent<Renderer>().material.SetColor("_EmissionColor", baseColor);
            }
           if(soundPlay)
            {
                GetComponent<AudioSource>().Stop();
                soundPlay = false;
            }
        }
        
    }
}
