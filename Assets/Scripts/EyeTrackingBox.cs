using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EyeTrackingBox : MonoBehaviour
{

    public ActivationReticle reticle;
    bool _hoveringAnObject;
    GameObject hoveredObject;
   // OVREyeGaze eyeGaze;

    private void Start()
    {
        /*
        eyeGaze = GetComponent<OVREyeGaze>();
        if (!eyeGaze.ApplyPosition)
            eyeGaze.ApplyPosition = true;
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (eyeGaze.ApplyPosition)
            eyeGaze.ApplyPosition = false;
        */
        if (other.CompareTag("Interactable"))
        {
            other.gameObject.GetComponent<Interactable>().enabled = true;
            hoveredObject = other.gameObject;
            _hoveringAnObject = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            other.gameObject.GetComponent<Interactable>().isHovered = false;
            _hoveringAnObject = false;
            reticle.CompletePercnt = 0;
           hoveredObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_hoveringAnObject)
        {
            reticle.CompletePercnt = 1 - hoveredObject.GetComponent<Interactable>().timer / hoveredObject.GetComponent<Interactable>().timeToActivate;

        }
    }
}
