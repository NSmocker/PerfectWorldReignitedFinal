using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class GestureControll : MonoBehaviour
{
 
    public UnityEvent unity_event;
    public void reactivateGameObject(GameObject to_reactivate) 
    { 
        bool is_act = to_reactivate.activeSelf;
        is_act = !is_act;
        to_reactivate.SetActive(is_act);
    }

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
