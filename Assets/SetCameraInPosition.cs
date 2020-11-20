using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraInPosition : MonoBehaviour
{

    public GameObject pos1, pos2, pos3;
    public Vector3 from_pos, to_pos;
    public Quaternion from_rot, to_rot;
    public GameObject lookAt;


    public float Lerper;
    public bool StartLerp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToPos1() 
    {
        Lerper = 0;
        from_pos = transform.position;
        to_pos = pos1.transform.position;
        from_rot = transform.rotation;
        to_rot = pos1.transform.rotation;
        StartLerp = true;
    }

    public void ToPos2()
    {
        Lerper = 0;
        from_pos = transform.position;
        to_pos = pos2.transform.position;
        from_rot = transform.rotation;
        to_rot = pos2.transform.rotation;
        StartLerp = true;
    }
    public void ToPos3()
    {
        Lerper = 0;
        from_pos = transform.position;
        to_pos = pos3.transform.position;
        from_rot = transform.rotation;
        to_rot = pos3.transform.rotation;
        StartLerp = true;
    }


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookAt.transform);

        if (StartLerp == true) 
        {
            Lerper += Time.deltaTime;
            transform.position = Vector3.Lerp(from_pos,to_pos,Lerper);
          //  transform.rotation= Quaternion.Lerp(from_rot, to_rot, Lerper);
            if (Lerper > 1) StartLerp = false;
        }

    }
}
