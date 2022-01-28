using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CharMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController Controller;
    [SerializeField] private float Speed;
    [SerializeField] private float rotationSpeed;
    public bool grounded;
    private Vector3 moveDirection;
    private float gravity = 2f;
    private float v;

    [Header("Navigation")]
    public Transform currentCamera;
    private Vector3 CamDirection;
    private CinemachineVirtualCamera Cam;

    
    // Start is called before the first frame update
    void Start()
    {
        Cam = currentCamera.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        Vector3 flatMove = (Speed * Time.deltaTime * direction);

        Vector3 CamFwd = currentCamera.forward;
        Vector3 CamRt = currentCamera.right;

        CamFwd.y = 0;
        CamRt.y = 0;

        CamFwd = CamFwd.normalized;
        CamRt = CamRt.normalized;


        Vector3 d = (CamFwd*direction.z + CamRt*direction.x);
        moveDirection = d*Time.deltaTime*Speed;

        if(Controller.isGrounded){
            moveDirection.y = 0f;
        }
        else{
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(d, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed*Time.deltaTime);
        }

        Controller.Move(moveDirection);
        grounded = Controller.isGrounded;
    }

    public void switchCam(Transform camChange){
        Cam.Priority = 0;
        currentCamera = camChange;
        Cam = currentCamera.GetComponent<CinemachineVirtualCamera>();
        Cam.Priority = 1;
    }
}
