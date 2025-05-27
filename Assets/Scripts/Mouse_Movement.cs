using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse_Movement : MonoBehaviour
{
    [SerializeField] private float mouseSens = 100f;

    [SerializeField] private Transform player;

    public bool cursorEnabled;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursorEnabled = false;
    }
    private void Update()
    {
        if (cursorEnabled == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }
    }
}
