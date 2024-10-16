using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey("left"))
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
