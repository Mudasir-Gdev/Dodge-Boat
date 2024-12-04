using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JoyStickMove : MonoBehaviour
{
    public Joystick joystick;
    public GameObject Shield;
   
    private Rigidbody rb;
    public float boatSpeed;
    public float steer;

    
    public PowerUpSpawner PSpawner;


    private GameManager GM;
    public UImanager UI;
    private void Start()
    {
        PSpawner = GameObject.Find("PowerUp Spawner").GetComponent<PowerUpSpawner>();
        rb = GetComponent<Rigidbody>();
        
        GM = GetComponent<GameManager>(); 
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
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shield"))
        {
            Shield.SetActive(true);
            PSpawner.Power.Remove(other.gameObject);
            Destroy(other.gameObject);
            
            
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            UI.scored =true;
            PSpawner.Power.Remove(other.gameObject);
            Destroy(other.gameObject);
            

        }
        else if (other.gameObject.CompareTag("SpeedUp"))
        {
            PSpawner.Power.Remove(other.gameObject);
            Destroy(other.gameObject);
            
            StartCoroutine(SpeedUp());
            
        }
    }
    IEnumerator SpeedUp()
    {
        boatSpeed = 25;
        yield return new WaitForSeconds(12);
        boatSpeed = 17;
    }
    
        
       
    
}
