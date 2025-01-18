using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 inputDir;
    private Vector3 rotation;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDir += Vector3.right;
        }
        inputDir.Normalize();
        Vector3 move = transform.forward * inputDir.z + transform.right * inputDir.x;
        transform.position += move * (moveSpeed * Time.deltaTime);

        rotation = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            rotation = Vector3.up;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation = Vector3.down;
        }
        transform.eulerAngles += (rotation * (rotationSpeed * Time.deltaTime));

    }
}
