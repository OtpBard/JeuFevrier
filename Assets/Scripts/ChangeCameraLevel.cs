using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraLevel : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public int newCameraLevel;
    private int pastCameraLevel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pastCameraLevel = cameraFollow.currentCameraLevel;
            cameraFollow.ChangeCameraLevel(newCameraLevel);
            newCameraLevel = pastCameraLevel;
        }
    }

}
