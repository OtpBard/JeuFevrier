using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    public float jumpForce;
    public float jumpDuration;
    public GameObject[] gameObjectColorChange;
    public float colorChangeDuration;
    [ColorUsage(true, true)]
    public Color newColor;
    [ColorUsage(true, true)]
    public Color baseColor;
    private float colorChangeTimer = 0.0f;
    private GameObject player = null;
    private float currentTimer = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            currentTimer = 0.0f;
            foreach(GameObject go in gameObjectColorChange)
            {
                go.GetComponent<Renderer>().material.SetColor("_EmissionColor", newColor);
            }

            colorChangeTimer = colorChangeDuration;
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * (jumpDuration - currentTimer) / jumpDuration, ForceMode.Force);
            currentTimer += Time.deltaTime;

            if (currentTimer > jumpDuration)
            {
                currentTimer = 0.0f;
                player = null;
            }
        }

        if (colorChangeTimer > 0.0f)
        {
            colorChangeTimer -= Time.deltaTime;
            if (colorChangeTimer <= 0.0f)
            {
                foreach(GameObject go in gameObjectColorChange)
                {
                    go.GetComponent<Renderer>().material.SetColor("_EmissionColor", baseColor);
                }
            }
        }
    }

}

