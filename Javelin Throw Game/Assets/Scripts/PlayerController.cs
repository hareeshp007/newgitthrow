using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PowerUp = 3;
    public Throwforce Throwforce;
    public float speed;
    public Rigidbody rb;
    private bool isTapped, IsSpawned=false ;
    public bool leastpower;
    private float TimesincelastTap, timeoftapended, throwforce=10f, holdtime=1f,destroytime=10f;
    public Transform attackPoint,weapon;
    public GameObject prefab, instantiatedObject, parentObject;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        leastpower = false;
    }
    private void Update() {

        //instantiatedObject.transform.parent = weapon;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if(touch.phase == TouchPhase.Began)
            {
                isTapped = true;
                TimesincelastTap=Time.time;

            }
            if(touch.phase == TouchPhase.Ended)
            {
                isTapped=false;
                Debug.Log("Ended");
                TimesincelastTap = 0f;
                if (IsSpawned && leastpower) { 
                Throw();
               
                
                }

            }
            if (isTapped)
            {
                moveCharacter();
                if (IsSpawned)
                {
                    Transform grandchildTransform = parentObject.transform.GetChild(0);
                    if (grandchildTransform != null)
                    {
                        //Debug.Log("child transform ");
                        //grandchildTransform.transform.LookAt(parentObject.transform.position);
                        //grandchildTransform.transform.SetParent(transform.parent, true);
                    }
                }
                if (Time.time - TimesincelastTap >= holdtime)
                {
                    //Debug.Log("leastpower");
                    leastpower=true;
                }
            }
        }
        

    }
 
   
    void moveCharacter()
    {
        Vector3 dir = new Vector3(1f, 0f, 0f);
        rb.velocity=(dir * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playarea"&& IsSpawned==false)
        {
            GameObject instantiatedObject =Instantiate(prefab, weapon.position, Quaternion.Euler(0f, 0f, 90f),weapon);
            instantiatedObject.transform.SetParent(weapon.transform, true);
            IsSpawned = true;
           
        }
        if(collision.gameObject.tag == "PowerUp")
        {
            PowerUp = 6;
            
        }
    }
    public int ReceiveValue()
    {
        return PowerUp;
    }
    void Throw()
    {
        Transform grandchildTransform = parentObject.transform.GetChild(0);
        if (grandchildTransform != null) {
            //Debug.Log("child found ");
            Rigidbody childrb = grandchildTransform.gameObject.GetComponent<Rigidbody>();
            childrb.isKinematic = false;
            //childrb.AddForce(Vector3.right * throwforce, ForceMode.VelocityChange);
            //childrb.velocity = (Vector3.right * throwforce);
        }

        //GameObject instantiatedObject = Instantiate(prefab, attackPoint.position, Quaternion.Euler(0f, 0f, 90f), weapon);
        //instantiatedObject.GetComponent<Rigidbody>().AddForce(Vector3.right * throwforce, ForceMode.Impulse);
    }
    public void Destroyplayer()
    {
        Destroy(gameObject);
    }
}
