using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;         // Speed of forward movement
    public Transform targetObject;       // Optional: Target to reach (used if you want to stop)

    private bool stopAtTarget = false;
    private float fixedY;                // Store the initial Y position

    void Start()
    {
        
        fixedY = transform.position.y;
    }

    void Update()
    {
        if (targetObject != null)
        {
            Vector3 targetPosition = new Vector3(targetObject.position.x, fixedY, targetObject.position.z);
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > 0.1f)
            {
                // Move toward the target, locking Y axis
                Vector3 direction = (targetPosition - transform.position).normalized;
                Vector3 movement = direction * moveSpeed * Time.deltaTime;
                transform.position += new Vector3(movement.x, 0f, movement.z);
            }
            else if (!stopAtTarget)
            {
                stopAtTarget = true;
                Debug.Log("Reached Target!");
            }
        }
        else
        {
            // Move straight forward in local Z direction (runner-style), locking Y axis
            Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
            transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
        }

        // Lock the Y position to fixedY
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, fixedY, pos.z);
    }

}
