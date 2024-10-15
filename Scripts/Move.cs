using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public GameObject cube;
    public GameObject sphere;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //MoveAndRotateTowardSphere();
        MoveSphere();
    }

    void MoveCube()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        cube.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
    void MoveSphere()
    {
        float horizontal = Input.GetAxis("HorizontalSphere");
        float vertical = Input.GetAxis("VerticalSphere");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        sphere.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
    void MoveCubeTowardsSphere()
    {
        Vector3 direction = sphere.transform.position - cube.transform.position;
        direction.y = 0;

        Vector3 moveDirection = direction.normalized;

        cube.transform.Translate(moveDirection * (speed - 2) * Time.deltaTime, Space.World);
    }
    void MoveAndRotateTowardSphere()
    {
        cube.transform.LookAt(sphere.transform);
        cube.transform.Translate(Vector3.forward * (speed - 2) * Time.deltaTime);
    }
}