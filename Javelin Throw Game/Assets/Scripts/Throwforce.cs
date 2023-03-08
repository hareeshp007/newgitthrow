using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwforce : MonoBehaviour
{

    public PlayerController power;
    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public Rigidbody Rb;
    public float throwforce;
    public int PowerUp;
    public bool valuereceived=false;

    // Start is called before the first frame update
    void Start()
    {
        Rb= GetComponent<Rigidbody>();
       
        Debug.Log(PowerUp);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetKeyDown(throwKey))
    //    //{
    //    //    Throw();
    //    //}

    //}
    private void Update()
    {
        Rb.transform.parent = transform;
        if (!Rb.isKinematic)
        {
            
            
            if (!valuereceived)
            {
                PowerUp = FindObjectOfType<powerup>().sendvalue();
                valuereceived = true;
            }
             Rb.AddForce(Vector3.right * throwforce, ForceMode.Impulse); 
            
        }
        
    }
    private void FixedUpdate()
    {
        
        
        //PowerUp = power.sendvalue();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                //Throw();

            }
        }

    }
     private void Throw(){
        Rb.AddForce( Vector3.right  * throwforce,ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        //if (collision.gameObject.tag=="PowerUp" && Rb.isKinematic)
        //{
        //    Debug.Log("PowerUp");
        //    Destroy(collision.gameObject);
            
        //    PowerUp = 6;
        //}
        if (collision.gameObject.tag=="Obstacle" && PowerUp > 0)
        {

            Debug.Log("obstacle " + PowerUp);
            Destroy(collision.gameObject);
            PowerUp--;
        }
        if (PowerUp == 0)
        {
            Destroy(gameObject);
        }
         
    }
    
}
