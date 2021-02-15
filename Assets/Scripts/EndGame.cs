using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public float endScreenDelay;
    public SpriteRenderer endGame;
    public float showEndGameDelay;
    private bool showUnscreen = false;
    private float triggerTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showUnscreen)
        {
            if (Time.time - triggerTime > endScreenDelay)
            {
                GetComponent<ScenesChange>().ChangeScene();
            }
            Color newColor = Color.white;
            newColor.a = (Time.time - triggerTime) / showEndGameDelay;
            endGame.color = newColor;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !showUnscreen)
        {
            showUnscreen = true;
            triggerTime = Time.time;
            endGame.enabled = true;
        }
    }
}
