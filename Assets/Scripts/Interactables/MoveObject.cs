using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    enum Direction {Forward, Backwards, Left, Right};
    [SerializeField]
    Direction _direction;

    [Range(0f, 50f)]
    public float Speed = 1;

    Vector3[] Directions = new Vector3[4]; 

    public bool activated;
    public GameObject ObjectToMove;
    private void Start()
    {
        Directions[0] = ObjectToMove.transform.forward;
        Directions[1] = -ObjectToMove.transform.forward;
        Directions[2] = -ObjectToMove.transform.right;
        Directions[3] = ObjectToMove.transform.right;
        
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
        ObjectToMove.transform.Translate(Directions[(int)_direction] * Speed * Time.deltaTime);

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
