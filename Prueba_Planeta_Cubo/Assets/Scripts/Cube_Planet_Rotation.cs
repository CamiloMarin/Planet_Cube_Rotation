using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Planet_Rotation : MonoBehaviour
{
    [Header("Planeta al cual aplicar las físicas")]
    public Transform Planet_Cube_Transform;

    [Header("Bool que reviza si hay contacto con los triggers que se encuentran al rededor de las arístas del planeta")]
    [SerializeField]
    private bool is_time_to_Rotate;

    [Header("Velocidad de rotación del planeta")]
    [SerializeField]
    private float Speed_Planet_Rotation = 0.5f;

    [Header("Tiempo de reinicio de cada rotación")]
    [SerializeField]
    private float Time_Rotation_Planet = 1.0f;

    // Variable de la lógica del tiempo en la rotación
    private float Reseter_Time_Rotation_Planet;

    void Start()
    {
        // Inicializamos la variable de Bool de rotación
        is_time_to_Rotate = false;

        // Igualamos las variables del tiempo
        Reseter_Time_Rotation_Planet = Time_Rotation_Planet;
    }

    // Cuando el jugador (PLayer) toca un trigger:
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_Rotation")
        {
            is_time_to_Rotate = true;
        }
    }

    void Update()
    {
        // Si el planeta puede rotar:
        if (is_time_to_Rotate)
        {
            // Asignamos a una variable local la dirección inversa al cual el planeta tiene que rotar
            Quaternion newRotation =
                Quaternion.Inverse(transform.rotation) * Planet_Cube_Transform.rotation;

            // Rotamos con una interpolación al objeto planeta teniendo en cuenta la dirección de "newRotation"
            Planet_Cube_Transform.rotation = Quaternion.Lerp(
                Planet_Cube_Transform.rotation,
                newRotation,
                Speed_Planet_Rotation * Time.deltaTime
            );

            Time_Rotation_Planet -= Time.deltaTime;

            if (Time_Rotation_Planet < 0)
            {
                is_time_to_Rotate = false;
                Time_Rotation_Planet = Reseter_Time_Rotation_Planet;
            }
        }
    }
}

