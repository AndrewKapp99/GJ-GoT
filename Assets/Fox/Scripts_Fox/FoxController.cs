using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FoxController : MonoBehaviour
{

    //[SerializeField]
    //protected KeyCode forward = KeyCode.W;

    public Rigidbody body;
    public Vector3 velocity;
    public float forwardInput;
    [SerializeField]
    protected float speed = 2;

    //public CinemachineVirtualCamera vcOne, vcTwo, vcThree;

    private void Awake()
    {
        velocity = Vector3.zero;
    }

    void Start()
    {
        
    }

    void Update()
    {
        //should this be in FixedUpdate?
        forwardInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "VC Trigger Two")
        {
            ResetCamPriority();
            vcTwo.m_Priority = 100;
        }
        else if (other.name == "VC Trigger First")
        {
            ResetCamPriority();
            vcOne.m_Priority = 100;
        }
        else if (other.name == "VC Trigger One")
        {
            ResetCamPriority();
            vcThree.m_Priority = 100;
        }
    }*/

    /*private void ResetCamPriority()
    {
        vcOne.m_Priority = 10;
        vcTwo.m_Priority = 10;
        vcThree.m_Priority = 10;
    }*/
}
