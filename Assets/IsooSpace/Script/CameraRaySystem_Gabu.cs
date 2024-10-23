using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRaySystem_Gabu : MonoBehaviour
{
    public PlayerInput playerInput;
    public float rayDistance = 100f;

    void Update()
    {
        if (playerInput.actions["Shot"].triggered)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Handle raycast hit
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            }
        }
    }
}
