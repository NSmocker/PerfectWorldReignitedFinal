using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_CustomController : MonoBehaviour
{

    public GameObject hovered;
    public GameObject attached;
    public float dist;
    public GameObject My_Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GrabItem") 
        {
            hovered = other.transform.parent.gameObject;
        }




        /* menu open section*/
        if (other.tag == "gesture_point")
        {
            var gesture = other.gameObject.GetComponent<GestureControll>();
            gesture.unity_event.Invoke();
        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (hovered!=null &&  other.gameObject == hovered)
        {
            hovered = null;
        }
    }
    public void GrabItem() 
    {
        if (hovered != null) 
        {
            hovered.transform.position = transform.position;
            hovered.transform.parent = transform; 
            attached = hovered.gameObject;
            attached.GetComponent<Rigidbody>().isKinematic = true;
           
           

        }
    }
    public void Release()
    {
        if (attached != null)
        { attached.GetComponent<Rigidbody>().isKinematic = false; attached.transform.parent = null; }
    }




    // Update is called once per frame
    void Update()
    {



        if (hovered != null) 
        {
            dist = Vector3.Distance(hovered.transform.position, transform.position);
            if (dist > 0.2f) hovered = null;
        }
    }
}
