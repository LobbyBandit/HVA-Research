using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResearchTimer : MonoBehaviour
{


    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnDisable()
    {
        //Debug.Log("Your Time :" + timer);
     
        Debug.Log("<color=yellow>------------------------------------- Your Time : </color>" + timer.ToString("0.00") + "<color=yellow>  ----------------------- </color>");
    }

}
