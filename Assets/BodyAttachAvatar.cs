using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAttachAvatar : MonoBehaviour
{
    public GameObject body_model;
    public Vector3 body_y_offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


      body_model.transform.position =   transform.position+ body_y_offset ;

      var b_rot = transform.eulerAngles;
      b_rot.x=body_model.transform.eulerAngles.x;
      b_rot.z=body_model.transform.eulerAngles.z;
      body_model.transform.eulerAngles = b_rot;


    }
}
