using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MonoBehaviour
{


    public float speed = 1f, gravityMultiplier = 1f;

    public CharacterController characterController;
    public GameObject cam, player;
    public Vector2 walk_input, look_input;

    // Start is called before the first frame update
    void Start()
    {

    }

    void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        characterController.Move(gravity * Time.deltaTime);

    }
    void Movment() 
    {
        player.transform.eulerAngles += new Vector3(0, look_input.x, 0);
        cam.transform.eulerAngles += new Vector3(-look_input.y, 0, 0);
        characterController.Move(player.transform.TransformDirection( new Vector3(walk_input.x, 0, walk_input.y)) * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {

        }

    }
    // Update is called once per frame
    void Update()
    {
        walk_input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        look_input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Movment();
        ApplyGravity();
        
    }
}
