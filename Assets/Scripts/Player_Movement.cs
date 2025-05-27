using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    public float interactionRange = 5.0f;
    public Camera playerCamera;
    private Animator player;

    private Vector3 velocity;
    private float gravity = -9.8f;
    private bool isGrounded;
    private float speed = 5f;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    void Start()
    {
        player = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
            {
                TowerInteraction interactable = hit.collider.GetComponent<TowerInteraction>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        player.SetFloat("Velocityx", x);
        player.SetFloat("Velocityz", z);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move.normalized * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
