using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "plane")
        {
            Debug.Log("Colisión con: " + collision.gameObject.tag);
        }
    }
}
