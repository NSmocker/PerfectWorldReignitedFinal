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
      b_rot.x=0;
      b_rot.z=0;
      body_model.transform.eulerAngles = b_rot;


    }
}
