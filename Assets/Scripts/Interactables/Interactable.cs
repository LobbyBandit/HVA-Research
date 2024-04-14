using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public float timeToActivate;
    [HideInInspector]
    public float timer;

    //[HideInInspector]
    public bool isHovered;

    public UnityEvent InstantActivate;
    public UnityEvent DelayedActivate;
    public UnityEvent OnDeactivate;

    void OnEnable()
    {
        timer = timeToActivate;
        isHovered = true;
    }

    private void Update()
    {
        if (!isHovered)
        {          
            OnDeactivate.Invoke();
            timer = timeToActivate;
                    enabled = false;
        }
        
        InstantActivate.Invoke();

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, timeToActivate);
        
        //Debug.Log("Time to Activate " + timer);

        if (timer > 0)
            return;
        else
        {
            DelayedActivate.Invoke();
        }

    }

    public void StoppedHovering()
    {
       isHovered = false;
    }

    private void OnDisable()
    {
        isHovered = false;
        OnDeactivate.Invoke();
    }





}
