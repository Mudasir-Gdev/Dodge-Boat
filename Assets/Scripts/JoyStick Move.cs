using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float boatSpeed;
    public float steer;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Particles effects
    }
    private void FixedUpdate()
    {
        transform.Translate(   Vector3.forward *boatSpeed*Time.deltaTime);
        Vector3 dir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Quaternion rotation = Quaternion.LookRotation(dir);
        Quaternion SmoothRotate = Quaternion.Lerp(transform.rotation, rotation, steer * Time.deltaTime);
        
        if (joystick.Direction.y != 0)
        rb.MoveRotation(SmoothRotate);  
        }
}
