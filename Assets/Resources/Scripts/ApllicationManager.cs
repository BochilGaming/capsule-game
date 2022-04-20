using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApllicationManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit(0);
    }
}
