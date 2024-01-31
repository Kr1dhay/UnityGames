using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensVert = 100f;
    public float mouseSensHor = 150f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensHor * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensVert * Time.deltaTime; 

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
