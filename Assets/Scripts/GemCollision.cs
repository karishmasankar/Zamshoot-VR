using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
    public float speed = 10f; // Speed of rotation in degrees per second
    
    public int gemValue = 10;
    public Transform playerTransform;
    public float destroyBuffer = 2f; // small buffer distance behind player

    private bool isCollected = false;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime); 

        
        if (!isCollected && playerTransform.position.z - transform.position.z > destroyBuffer)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            isCollected = true;
            GameManager.instance.AddScore(gemValue);
            Destroy(gameObject);
        }
    }
}