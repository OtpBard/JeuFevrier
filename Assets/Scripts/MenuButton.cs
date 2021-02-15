using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Text buttonText = null;

   void Start()
   {
       GameObject[] objs = GameObject.FindGameObjectsWithTag("MenuButtonSound");

        if (objs.Length >= 1)
        {
            GetComponent<Button>().onClick.AddListener(objs[0].GetComponent<AudioSource>().Play);
        }
   }
   public void OnMouseHover()
   {
       buttonText.color = new Color(165/255.0f, 255/255.0f, 243/255.0f);
   }

   public void OnMouseExit()
   {
       buttonText.color = Color.white;
   }
}
