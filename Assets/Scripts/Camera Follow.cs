using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform boat;

    

    
    void FixedUpdate()
    {
        Vector3 posOffset = new Vector3(0,24,-8f);
        transform.position =boat.position+posOffset;
    }
}
