using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_CustomController : MonoBehaviour
{

    public GameObject hovered;
    public GameObject attached;
    public float dist;
    public GameObject My_Player;



    public bool isGrabed;
    public Animator Hand3DModel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitAnimator());
    }

    public IEnumerator InitAnimator() 
    {
        yield return new WaitForSeconds(2);
        Hand3DModel = GetComponentInChildren<Animator>();
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
        isGrabed = true;
        if (hovered != null) 
        {
            hovered.transform.position = transform.position;
            hovered.transform.rotation= transform.rotation;

            hovered.transform.parent = transform; 
            attached = hovered.gameObject;
            attached.GetComponent<Rigidbody>().isKinematic = true;
           
           

        }
    }
    public void Release()
    {
        isGrabed = false;
        if (attached != null)
        { attached.GetComponent<Rigidbody>().isKinematic = false; attached.transform.parent = null; }
    }




    // Update is called once per frame
    void Update()
    {
        if (Hand3DModel != null) 
        {
            Hand3DModel.SetBool("Grab", isGrabed);
        }



        if (hovered != null) 
        {
            dist = Vector3.Distance(hovered.transform.position, transform.position);
            if (dist > 0.2f) hovered = null;
        }
    }
}
