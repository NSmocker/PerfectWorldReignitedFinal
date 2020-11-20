using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRTriggerButton : MonoBehaviour
{
    
    public UnityEvent Command;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {

        Command.Invoke();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
