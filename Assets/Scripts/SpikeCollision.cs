using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public float speed = 10f; 

    public Transform playerTransform;
    public float destroyBuffer = 2f; 
          
    private bool isCollided = false;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.left, speed * Time.deltaTime); 

        
        if (!isCollided && playerTransform.position.z - transform.position.z > destroyBuffer)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            Debug.Log("spike hit");
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }
    
}