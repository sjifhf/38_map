using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_ViewType : MonoBehaviour
{
    public PlayerMovement_3D playerMovement_3D;
    public PlayerMovement_2D playerMovement_2D;
    public rotationchanging rotationScript;
    public MouseLook mouseLook;
    bool is2D = false;
    bool is3D = true;
    // Start is called before the first frame update
    void Start()
    {
        is2D = false;
        is3D = true;

        playerMovement_3D.enabled = true;
        playerMovement_2D.enabled = false;

        rotationScript.enabled = false;
        mouseLook.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationScript.enabled == false || is3D == true)
        {
            is2D = false;

            rotationScript.enabled = false;
            mouseLook.enabled = true;
        }
        if (mouseLook.enabled == false || is2D == true)
        {
            is3D = false;
        
            playerMovement_2D.enabled = true;
            rotationScript.enabled = true;
            mouseLook.enabled = false;
        }
    }
}
