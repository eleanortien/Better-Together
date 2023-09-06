using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public GameObject screen;
    public Sprite clueNumber;

    
    public void TriggerTerminal()
    {
      
            screen.GetComponent<SpriteRenderer>().sprite = clueNumber;
        
   
    }
}
