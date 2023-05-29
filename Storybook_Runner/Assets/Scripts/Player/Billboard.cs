using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void LateUpdate()
    {
        //Will always face towards the Player - Must be attached to a Canvas and hooked up with Main Camera
        transform.LookAt(transform.position + cam.forward);
    }

}
