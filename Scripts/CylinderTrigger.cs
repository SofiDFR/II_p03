using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("El objeto que ha entrado en el Trigger es: " + other.gameObject.tag);
    }
}
