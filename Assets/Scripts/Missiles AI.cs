using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesAI : MonoBehaviour
{
    private GameManager GM;
    
    private GameObject target;
    public float speed = 10f;
    public float rotationSpeed =5f;
    void Start()
    {
        target = GameObject.Find("Player");
        GM = gameObject.AddComponent<GameManager>();
        Destroy(gameObject, 10);
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
        //Explosion particles
        Destroy(gameObject);
        Destroy(collision.gameObject);
        if (collision.gameObject == GameObject.Find("Player"))
        {
            
            GM.GameOver();
        }
        
    }

}
