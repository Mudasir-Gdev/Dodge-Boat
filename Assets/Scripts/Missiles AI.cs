using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesAI : MonoBehaviour
{
    private GameManager GM;
    public GameObject Explode;
    public GameObject GameOver;
    private GameObject target;
    public float speed = 10f;
    public float rotationSpeed =5f;
    void Start()
    {
        target = GameObject.Find("Player");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 15);
        

    }

    // Update is called once per frame
    void Update()
    {
        
        //Particles
        if (target == null) return;
    
        Vector3 dir = (target.transform.position- transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed*Time.deltaTime);

        transform.Translate(Vector3.forward *speed *Time.deltaTime);
    }
    private Vector3 Moveprediction()
    {
        var Target = target.transform.forward * 0.5f ; 
        return Target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.SetActive(false);
            Explod();
        }
        else
        {

            Explod();
            Destroy(collision.gameObject);
            if (collision.gameObject == GameObject.Find("Player"))
            {

                GM.gameover();
                
            }

        }
    }
    void Explod()
    {
       Instantiate(Explode,transform.position, Quaternion.identity);    
        Destroy(gameObject);
    }

}
