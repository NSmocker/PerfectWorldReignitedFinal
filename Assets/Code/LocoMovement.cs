using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(CharacterController))]
public class LocoMovement : LocomotionProvider
{
    public float speed = 1f, gravityMultiplier = 1f;
    public List<XRController> controllers = null;
    private CharacterController characterController = null;
    public CapsuleCollider capsule;
    GameObject head = null;
    public float gravity = -9;
    public float Jump_Force=3;

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        PositionController();
    }

    // Update is called once per frame
    void Update()
    {
        PositionController();
        CheckForInput();
        ApplyGravity();
    }
    void PositionController() 
    {
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;
        characterController.center = newCenter;
        capsule.center = newCenter;
        capsule.height= headHeight;
    }


    public void Jump() 
    {
        gravity = Jump_Force;
    }
    void ApplyGravity() 
    {
        if (gravity > -10) gravity -= Time.deltaTime;
        Vector3 gravity_dir = new Vector3(0, gravity * gravityMultiplier, 0);
        
        characterController.Move(gravity_dir * Time.deltaTime);
        
    }
    void CheckForInput() 
    {
        foreach (XRController controller in controllers) 
        {
            if (controller.enableInputActions) CheckForMovement(controller.inputDevice);
        }



        var default_input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        characterController.Move(Camera.main.transform.TransformDirection(new Vector3(default_input.x*speed*Time.deltaTime,0,default_input.y*speed * Time.deltaTime)));
    }
    void CheckForMovement(InputDevice device) 
    {
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position)) 
        {
            StartMove(position);
        }
    }
    void StartMove(Vector2 position) 
    {
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);
        direction = Quaternion.Euler(headRotation) * direction;
        Vector3 movment = direction * speed;
        characterController.Move(movment * Time.deltaTime);
    }


}
