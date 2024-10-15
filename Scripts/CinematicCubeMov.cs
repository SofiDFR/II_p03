using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCubeMov : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection.magnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
       
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
}
