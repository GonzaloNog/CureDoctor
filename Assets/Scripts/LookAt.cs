using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        // Si no se asigna la cámara en el Inspector, se usa la cámara principal.
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // El objeto mira hacia la cámara.
        transform.LookAt(cameraTransform);
    }
}
