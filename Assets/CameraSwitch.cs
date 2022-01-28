using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform SwitchCam;
    [SerializeField] private GameObject Player;
    private CharMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = Player.GetComponent<CharMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject == Player){
            playerMove.switchCam(SwitchCam);
        }
    }
}
