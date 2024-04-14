using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ActivationReticle : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public float distance = 2f;
   // Vector3 moveDirection = Vector3.forward;
    
    public Image reticle;
    [HideInInspector] 
    public float CompletePercnt;

    void Start()
    {
    }

    private void Update()
    {
        /*
        if (object1 != null && object2 != null)
        {
            // Calculate the midpoint between the forward-facing directions of the two objects
            Vector3 midpoint = (object1.forward + object2.forward).normalized;

            // Calculate the position to move the object away from the midpoint along the specified direction
            Vector3 newPosition = midpoint + moveDirection.normalized * distance;

            // Move the object to the new position
            gameObject.transform.position = newPosition;
            gameObject.transform.LookAt((object1.transform.position + object2.transform.position) / 2);
        }
        */
        reticle.fillAmount = CompletePercnt;
        
    }
}


