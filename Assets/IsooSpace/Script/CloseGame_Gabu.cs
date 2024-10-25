using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame_Gabu : MonoBehaviour
{
    public GameObject obj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}
