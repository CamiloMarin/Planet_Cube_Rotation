using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Plannet_Gravity : MonoBehaviour
{
    [Header("Planeta al cual aplicar las físicas")]
    // Objeto que representará nuestro planeta y atractor
    public Transform Cube_Planet_Target;

    // Gravedad o fuerza de atracción del planeta objetivo
     [Header("Fuerza que se le aplica a la gravedad del planeta")]
    [SerializeField]
    private float gravity_Strength;

    // Rigidbody que está dentro de este objeto (Player)
    private Rigidbody this_Rb;

    void Start()
    {
        // Inicializamos la var del rigidbody de este objeto
        this_Rb = this.GetComponentInParent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Gravity_Behavior();
    }

    // Comportamiento de la gravedad del planeta cubo
    void Gravity_Behavior()
    {
        // vector que me da la dirección a la cual aplicar la fuerza
        Vector3 diff = transform.position - Cube_Planet_Target.position;

        // Aplico la fuerza de atracción  al rigidbody de este obj
        //(teniendo en cuenta que la fuerza es en forma de atracción entonces es en dirección contraria la dirección ppal)

        this_Rb.AddForce(-diff.normalized * gravity_Strength * (this_Rb.mass));
    }
}
