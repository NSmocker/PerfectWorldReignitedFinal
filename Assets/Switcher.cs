using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class Switcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NoVR());
    }
    IEnumerator StartXR()
    {

        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        XRGeneralSettings.Instance.Manager.activeLoader.Start();
        XRGeneralSettings.Instance.Manager.activeLoader.Deinitialize();
    }


    IEnumerator NoVR()
    {
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        XRGeneralSettings.Instance.Manager.activeLoader.Stop();
        XRGeneralSettings.Instance.Manager.activeLoader.Deinitialize();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
