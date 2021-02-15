using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{

    public float moveMaxSpeed = 10.0f;
    public float rotationSpeed = 10.0f;
    public float gravityForce;
    public GameObject impactEmiterGameObject;
    private bool isInAir = true;
    private ParticleSystem emiter = null;
    private float airTimer;
    private int floorCounter = 0;
    public AudioSource impactAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
         if(emiter == null)
        {
            emiter = impactEmiterGameObject.GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().AddForce(Vector3.right * horizontalInput * moveMaxSpeed, ForceMode.Force);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * verticalInput * moveMaxSpeed, ForceMode.Force);
        

        Vector3 targetDirection = (Vector3.right * horizontalInput + Vector3.forward * verticalInput).normalized;
        if(targetDirection.magnitude > 0.0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation , Time.deltaTime * rotationSpeed);
        }
       
       if(isInAir)
       {
           GetComponent<Rigidbody>().AddForce(Vector3.up * -1.0f * gravityForce, ForceMode.Force);
       }
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Floor")
        {
            floorCounter++;

            if (isInAir)
            {
                isInAir = false;
                if (Time.time - airTimer > 0.4f)
                {
                    var emitParams = new ParticleSystem.EmitParams();
                    emiter.Emit(emitParams, 10);
                    impactAudio.volume = 0.8f;
                    impactAudio.Play();
                }
                else if (Time.time - airTimer > 0.15f)
                {
                    var emitParams = new ParticleSystem.EmitParams();
                    emiter.Emit(emitParams, 5);
                    impactAudio.volume = 0.6f;
                    impactAudio.Play();
                }
            }
          
        }
    }

    void OnCollisionExit(Collision hit)
    {
        if(hit.gameObject.tag == "Floor")
        {
            floorCounter--;
            if (floorCounter == 0)
            {
                isInAir = true;
                airTimer = Time.time;
            }
           
        }
    }

     IEnumerator GoGameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<ScenesChange>().ChangeScene();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Despawn")
        {
            StartCoroutine(GoGameOverScreen());
        }
    }

}
