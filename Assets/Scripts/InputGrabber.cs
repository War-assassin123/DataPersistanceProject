using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGrabber : MonoBehaviour
{
    public string playerName;
    // Start is called before the first frame update
    public void GrabInput(string input)
    {
        playerName = input;
        
    }
}
