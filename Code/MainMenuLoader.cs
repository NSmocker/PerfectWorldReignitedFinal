using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update


    public void Set_Pos() 
    {
        transform.position = cam.transform.position + (cam.transform.forward/2);
        transform.LookAt(Camera.main.transform);

    }

    // Update is called once per frame
    void Update()
    {
        }
}
