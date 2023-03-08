using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject prefab, player;
    private GameObject objectpref ;
    public float respawnTime = 3f;
    public KeyCode throwKey = KeyCode.Mouse1;
    private bool isRespawning = true;
    private void Start()
    {
        
    }


   
    private void Update()
    {
        
        
        if (objectpref ==null || player ==null)
        {
            isRespawning = false;
        }
    }
    public void spawn()
    {
        if (!isRespawning) { 
        GameObject objectpref= Instantiate(prefab, attackPoint.position, Quaternion.identity);
        isRespawning = true;
        }
    }
}
