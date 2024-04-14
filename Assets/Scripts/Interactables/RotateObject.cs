using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    enum Direction { Up, Down, Left, Right };
    [SerializeField]
    Direction _direction;

    [Range(0f, 50f)]
    public float Speed = 1;

    Vector3[] Directions = new Vector3[4];

    public bool activated;
    public GameObject ObjectToRotate;

    private void Start()
    {
        Directions[0] = new Vector3(-1,0,0);
        Directions[1] = new Vector3(1, 0, 0);
        Directions[2] = new Vector3(0, -1, 0); 
        Directions[3] = new Vector3(0, 1, 0);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
            ObjectToRotate.transform.Rotate(Directions[(int)_direction] * Speed * Time.deltaTime);

        else
        {
            activated = false;
            enabled = false;
        }
    }

    public void Deactivate()
    {
        activated = false;
    }

}
