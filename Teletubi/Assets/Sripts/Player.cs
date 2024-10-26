using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float plaerspeed = 5.0f;
    public bool IA = false;
    BallController ballController;
    void Start()
    {
        ballController = FindObjectOfType<BallController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * plaerspeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * plaerspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.T))
        {
            IA=!IA;
        }

        if(IA)
        {
            Traking();
        }
    }

    void Traking()
    {
        if(ballController.transform.position.x > transform.position.x)
        {
            transform.Translate(Vector3.right * plaerspeed * Time.deltaTime);
        }
        else if(ballController.transform.position.x < transform.position.x)
        {
            transform.Translate(Vector3.left * plaerspeed * Time.deltaTime);
        }
    }

    public void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
    }
    public void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
