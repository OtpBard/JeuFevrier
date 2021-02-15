using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movingAxe;
    public float distanceMax;
    public float distanceMin;
    public float speed;
    public float pause;
    public AudioSource sound;
    private Vector3 normalizedAxe;
    private float currentDistance = 0.0f;
    private float pauseTimer;
    private bool goingForward = true;
    private Vector3 originalPosition;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        normalizedAxe = movingAxe.normalized;
        pauseTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseTimer > 0.0f)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0.0f && sound)
            {
                sound.Play();
            }
            return;

        }

        if(goingForward)
        {
            currentDistance += speed*Time.deltaTime;
            if(currentDistance > distanceMax)
            {
                float overtaking = currentDistance - distanceMax;
                currentDistance = distanceMax - overtaking;
                goingForward = false;
                pauseTimer = pause;
            }
        }
        else
        {
            currentDistance -= speed*Time.deltaTime;
            if(currentDistance < distanceMin)
            {
                float overtaking = currentDistance - distanceMin;
                currentDistance = distanceMin - overtaking;
                goingForward = true;
                pauseTimer = pause;
            }
        }

        transform.position = originalPosition + normalizedAxe*currentDistance;
        
    }
}

