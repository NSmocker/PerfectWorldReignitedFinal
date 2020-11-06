using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandModelPose : MonoBehaviour
{

  
    public Hand_CustomController hand;
    public Animator anim;
    void CheckParent()
    {
  
        var par = transform.parent;
        while (par != null)
        {
            var custom_hand = GetComponent<Hand_CustomController>();
            if (custom_hand == false)
            {
                par = par.transform.parent;
            }
            else { hand = custom_hand; break; }
            
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        CheckParent();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hand != null) 
        {
            anim.SetBool("Grab", hand.isGrabed);
        }
    }
}
