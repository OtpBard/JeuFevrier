using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow; 
    public Vector3 cameraAxe;
    public Vector3[] cameraStartPosition;
    public int currentCameraLevel = 0;
    public float changeCameraDuration;
    private Vector3 originalPosition;
    private float changeCameraTimer = 0.0f;
    private int pastCameraLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = cameraStartPosition[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow == null)
        {
            return;
        }

        if (changeCameraTimer > 0.0f)
        {
            originalPosition = Vector3.Lerp(cameraStartPosition[pastCameraLevel], cameraStartPosition[currentCameraLevel], (changeCameraDuration - changeCameraTimer) / changeCameraDuration);
            changeCameraTimer -= Time.deltaTime;
        }
        else
        {
            originalPosition = cameraStartPosition[currentCameraLevel];
        }

        Vector3 objectLocation = objectToFollow.transform.position;
        objectLocation.y = 0.0f;

        float projection = Vector3.Dot(objectLocation,cameraAxe);
        transform.position = originalPosition + cameraAxe*projection;

    }

    public void ChangeCameraLevel(int newLevel)
    {
        pastCameraLevel = currentCameraLevel;
        currentCameraLevel = newLevel;
        changeCameraTimer = changeCameraDuration;
    }
}
