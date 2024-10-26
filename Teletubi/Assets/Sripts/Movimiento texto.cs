using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientotexto : MonoBehaviour
{
    public bool moverEnX;
    public bool moverEnY;

    public bool positivo;

    public float speed = 1.0f;

    void Update()
    {
        float direccion = positivo ? 1.0f : -1.0f;
        Vector3 movimiento = Vector3.zero;

        if (moverEnX)
        {
            movimiento.x = direccion * speed * Time.deltaTime;
        }

        if (moverEnY)
        {
            movimiento.y = direccion * speed * Time.deltaTime;
        }
        transform.Translate(movimiento);
    }
}
