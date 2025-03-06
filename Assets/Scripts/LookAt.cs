using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        // Si no se asigna la c�mara en el Inspector, se usa la c�mara principal.
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // El objeto mira hacia la c�mara.
        transform.LookAt(cameraTransform);
    }
}
