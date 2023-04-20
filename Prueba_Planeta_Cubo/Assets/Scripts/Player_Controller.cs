using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Movimiento del Input Horizontal del personaje
    private float horizontalMove;

    // Movimeinto del Input Vertical del personaje
    private float verticalMove;

    // Velocidad del movimiento del personaje
    [SerializeField]
    private float PlayerSpeed;

    // Rigidbody que está dentro de este objeto
    private Rigidbody this_Rb;

    void Start()
    {
        // Inicializamos la var del rigidbody de este objeto
        this_Rb = this.GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento del personaje ***

        // Movimiento en el eje horizontal del personaje
        horizontalMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;

        // Movimiento en el eje vertical del personaje
        verticalMove = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;

        // Movimiento del personaje ***
    }

    // Fisicas de movimiento Horizontal y Vertical:
    void FixedUpdate()
    {
        this_Rb.velocity = new Vector3(horizontalMove, this_Rb.velocity.y, verticalMove);
    }
}

