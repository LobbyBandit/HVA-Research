using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class EyeTrackingRay : MonoBehaviour
{
    [SerializeField]
    float rayDistance = 1.0f;
    [SerializeField]
    float rayWidth = 0.01f;
    [SerializeField]
    Color rayColorDefaultState = Color.green;
    [SerializeField]
    Color rayColorActiveState = Color.green;

    LineRenderer lineRenderer;

    public ActivationReticle reticle;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupRay();
    }

    private void SetupRay()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorDefaultState;
        lineRenderer.endColor = rayColorDefaultState;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + rayDistance));
    }

    GameObject PreviousGameObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 rayCastDirection = transform.TransformDirection(transform.forward);

        if (Physics.Raycast(Vector3.zero, rayCastDirection, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                lineRenderer.startColor = rayColorActiveState;
                lineRenderer.endColor = rayColorActiveState;

                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, rayCastDirection * rayDistance);

                Debug.Log("We Hit An Interactable");

                GameObject Interactable = hit.collider.gameObject;
                if (Interactable == PreviousGameObject && PreviousGameObject != null)
                {
                    reticle.CompletePercnt = Interactable.GetComponent<Interactable>().timer / Interactable.GetComponent<Interactable>().timeToActivate;

                    return;
                }

                else if (Interactable != PreviousGameObject)
                {

                    //Disable previous GameObject and Enable the new one. Make the new game objet the previous one
                    if (PreviousGameObject != null)
                        PreviousGameObject.GetComponent<Interactable>().isHovered = false;
                    Interactable.GetComponent<Interactable>().enabled = true;
                    PreviousGameObject = Interactable;

                    reticle.CompletePercnt = Interactable.GetComponent<Interactable>().timer / Interactable.GetComponent<Interactable>().timeToActivate;
                }

                else if(PreviousGameObject == null)
                {
                    Interactable.GetComponent<Interactable>().enabled = true;
                    PreviousGameObject = Interactable;
                }
            }
            else
            {
                if (PreviousGameObject != null)
                    PreviousGameObject.GetComponent<Interactable>().isHovered = false;
                else
                    return;
                
                    PreviousGameObject = null;
                    reticle.CompletePercnt = 0;
                    lineRenderer.startColor = rayColorDefaultState;
                    lineRenderer.endColor = rayColorDefaultState;                           
            }

        }
    }

    private void Update()
    {


    }

    private void OnValidate()
    {
        //SetupRay();
    }



}
