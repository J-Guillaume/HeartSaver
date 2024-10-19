using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        ///to start game///////////
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ||
            OVRInput.Get(OVRInput.RawButton.RIndexTrigger) ||
            Input.GetKeyDown(KeyCode.B))//the b key is so we can test in unity before building
        {
 
            SceneManager.LoadScene("Hallway");//go to hallway scene

        }//end if trigger
    }
}
