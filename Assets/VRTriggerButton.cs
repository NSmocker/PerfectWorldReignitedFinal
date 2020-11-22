using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRTriggerButton : MonoBehaviour
{
    
    public UnityEvent Command;
    public string collider_name;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (collider_name != "")
        {
            print(other.name);
            if (collider_name == other.gameObject.name) Command.Invoke();
        }
        else { Command.Invoke(); }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
