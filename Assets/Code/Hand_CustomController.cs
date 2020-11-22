using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_CustomController : MonoBehaviour
{

    public GameObject hovered;
    public GameObject attached;
    public float dist;
    public GameObject My_Player;
    public float hover_cleaner;



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

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "GrabItem") 
        {
            hover_cleaner += 0.5f;
            if (other.transform.parent!=null) hovered = other.transform.parent.gameObject;
            else { hovered = other.transform.gameObject; }
           
        }




        /* menu open section*/
        if (other.tag == "gesture_point")
        {
            var gesture = other.gameObject.GetComponent<GestureControll>();
            gesture.unity_event.Invoke();
        }


    }
  /*  public void OnTriggerExit(Collider other)
    {
        if (hovered!=null &&  other.gameObject == hovered)
        {
            hovered = null;
        }
    }
  */
    public void GrabItem() 
    {
        isGrabed = true;
        if (hovered != null) 
        {
           // hovered.transform.position = transform.position;
        //    hovered.transform.rotation= transform.rotation;

            hovered.transform.parent = transform;
            hovered.GetComponent<Rigidbody>().isKinematic = true;
            attached = hovered.gameObject;

           
           

        }
    }
    public void Release()
    {
        isGrabed = false;
        if (attached != null)
        { attached.GetComponent<Rigidbody>().isKinematic = false; attached.transform.parent = null; }
        attached = null;
    }




    // Update is called once per frame
    void Update()
    {
        hover_cleaner -= Time.deltaTime;
        if (hover_cleaner > 0.5f) hover_cleaner = 0.5f;
        if (hover_cleaner < -0.5) hover_cleaner = -0.5f;


        if (Hand3DModel != null) 
        {
            Hand3DModel.SetBool("Grab", isGrabed);
        }

        if (Input.GetButtonDown("Jump")){ GrabItem(); }
        if (Input.GetButtonUp("Jump")) { Release(); }


        if (hovered != null) 
        {/*
            dist = Vector3.Distance(hovered.transform.position, transform.position);
            if (dist > 0.10f) hovered = null;
        */
            if (hover_cleaner <= 0)
            {
                hovered = null;
            }
        }
    }
}
