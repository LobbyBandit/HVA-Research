using UnityEngine;

public class PedalButton : MonoBehaviour
{
    public Vector3 activeTransform;
    public GameObject StartAnchor;
    public GameObject EndAnchor;

    Quaternion start;
    Quaternion end;

    public float SecondsToRotate;
    float rotationPercent;
    
    public bool isActivated;


    private void Awake()
    {
        start = StartAnchor.transform.rotation; 
        end = EndAnchor.transform.rotation;
        EndAnchor.SetActive(false);
    }

    private void OnEnable()
    {
        isActivated = true;      
    }

    // Update is called once per frame
    void Update()
    {
        ButtonAnim();
        //Debug.Log(rotationPercent);
    }

    void ButtonAnim()
    {
        if (!isActivated)
        {
            rotationPercent -= (1 / SecondsToRotate) * Time.deltaTime;
           

            
            if (rotationPercent <= 0)
            enabled = false;
            
        }     
        else
            rotationPercent += (1 / SecondsToRotate) * Time.deltaTime;

        rotationPercent = Mathf.Clamp01(rotationPercent);
        StartAnchor.transform.rotation = Quaternion.Slerp(start, end, rotationPercent);
    }


    private void OnValidate()
    {
        if (EndAnchor != null)
        {
            EndAnchor.transform.localRotation = Quaternion.Euler(activeTransform);
        } 
    }

    public void Deactivate()
    {
            isActivated = false;
    }
}
