using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public Transform sphere;
    public float moveSpeed = 5f;
    public float turnSpeed = 3f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("HorizontalCylinder");
        float vertical = Input.GetAxis("VerticalCylinder");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
           
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, toRotation, turnSpeed * Time.deltaTime);

            rb.AddForce(moveDirection * moveSpeed * 2f);
        }
        else
        {
            if (sphere != null)
            {
                Vector3 lookAtGoal = new Vector3(sphere.position.x, this.transform.position.y, sphere.position.z);

                Vector3 directionToSphere = (lookAtGoal - transform.position).normalized;

                Quaternion rotationToSphere = Quaternion.LookRotation(directionToSphere);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotationToSphere, turnSpeed * Time.fixedDeltaTime));
            }
        }
    }
}
