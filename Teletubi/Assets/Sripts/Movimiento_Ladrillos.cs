using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadrilloMovimiento : MonoBehaviour
{
    public float movementRange = 2.0f; 
    public float speed = 2.0f;        

    private Vector3 startPosition;    
    private int direction = 1;         

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= startPosition.x + movementRange)
        {
            direction = -1; 
        }
        else if (transform.position.x <= startPosition.x - movementRange)
        {
            direction = 1; 
        }
    }
}
