using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotation_Behavior : MonoBehaviour
{
    // Rigidbody que está dentro de este objeto
    private Rigidbody this_Rb;

    // Gravedad que se aplica a este objeto
     [Header("Fuerza (EXTRA) que se le aplica a la gravedad del planeta")]
    [SerializeField]
    private float gravitySpeed;

    void Start()
    {
        // Inicializamos la var del rigidbody de este objeto
        this_Rb = this.GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        // creamos un valor que reviza si alguna entidad está cerca al lanzar un raycast en la dirección del eje Z
        float distForward = Mathf.Infinity;

        // Creamos un raycast (esférico para más precisión) que iguale el valor de "disForward" a la distancia del impácto con el orignen
        RaycastHit hitForward;
        if (
            Physics.SphereCast(
                transform.position,
                0.25f,
                -transform.up + transform.forward,
                out hitForward,
                5
            )
        )
        {
            distForward = hitForward.distance;
        }

        // creamos un valor que reviza si alguna entidad está cerca al lanzar un raycast en la dirección del eje -Y
        float distDown = Mathf.Infinity;

        // Creamos un raycast para asignar el valor de la distancia del impácto en este eje
        RaycastHit hitDown;
        if (
            Physics.SphereCast(
                transform.position,
                 0.25f, -transform.up,
                  out hitDown, 
                  5
            )
        )
        {
            distDown = hitDown.distance;
        }

        // Creamos un valor para revizar si alguna entidad está cerca al lanzar un raycast en la dirección del eje -Z
        float distBack = Mathf.Infinity;

        // Creamos uN raycast para asignar el valor de la distancia del impácto en este eje
        RaycastHit hitBack;
        if (
            Physics.SphereCast(
                transform.position,
                0.25f,
                -transform.up + -transform.forward,
                out hitBack,
                5
            )
        )
        {
            distBack = hitBack.distance;
        }


        // Si la distancia de impácto en la dirección Z es mayor a la distancia de impácto del eje -Z & -Y, entonces:


        if (distForward < distDown && distForward < distBack)
        {
            // Creamos una interpolación a la rotación de este objeto (Player) relativo al producto de dos vectores (EJE z y la cara del suelo o planeta)
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(
                    Vector3.Cross(transform.right, hitForward.normal),
                    hitForward.normal
                ),
                Time.deltaTime * 5.0f
            );
        }
        else if (distDown < distForward && distDown < distBack) // Si la distancia de impácto del eje -Y es mayor a la distancia de impácto del eje Z & -Z, entonces:
        {
            // Creamos una interpolación a la rotación de este objeto (Player) relativo al producto de dos vectores (EJE -Y y la cara del suelo o planeta)
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(
                    Vector3.Cross(transform.right, hitDown.normal),
                    hitDown.normal
                ),
                Time.deltaTime * 5.0f
            );
        }
        else if (distBack < distForward && distBack < distDown)// Si la distancia de impácto del eje -Z es mayor a la distancia de impácto del eje Z & -Y, entonces:
        {
        {
            // Creamos una interpolación a la rotación de este objeto (Player) relativo al producto de dos vectores (EJE -Y y la cara del suelo o planeta)
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(
                    Vector3.Cross(transform.right, hitBack.normal),
                    hitBack.normal
                ),
                Time.deltaTime * 5.0f
            );
        }

        // Le aplicamos una fuerza (extra a la del script de "Cube_Planet_Gravity" para crear un efecto de rotación mas limpio) 
        this_Rb.AddForce(-transform.up * Time.deltaTime * gravitySpeed);
        }
    }
}
