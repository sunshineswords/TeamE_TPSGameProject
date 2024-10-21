using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay_Gabu : MonoBehaviour
{
    int i = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            i *= 2; // Increment i by 1
            Debug.Log("clicked " + i);
        }


        for (int j = 0; j < i; j++)
        {
            // Generate a random direction
            Vector3 randomDirection = Random.insideUnitSphere;

            // Generate a Raycast
            RaycastHit hit;
            Debug.DrawRay(transform.position, randomDirection * 300, Color.red, 1);
            Debug.Log("ray表示");

            if (Physics.Raycast(transform.position, randomDirection * 300, out hit))
            {
                // Handle the hit object
                GameObject hitObject = hit.collider.gameObject;
                hitObject.transform.position = new Vector3(Random.Range(-32f, 32f), Random.Range(-32f, 32f), Random.Range(-32f, 32f));
                // Do something with the hit object
                Debug.Log("hit " + hitObject.name);
                // Visualize the ray in the editor
            }
        }
    }
}
