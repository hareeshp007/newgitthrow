using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public int value=3;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("powerup");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerenter");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("trigger");
            value = 6;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("triggerexit");
            value = 3;
        }
    }
    public int sendvalue()
    {
        return value;
    }
    
}
