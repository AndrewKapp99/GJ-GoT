using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChange : MonoBehaviour
{
    [SerializeField] private string TargetAnimation;
    private CharAnimCont Controller;

    public void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            Controller = other.gameObject.GetComponent<CharAnimCont>();
            Controller.state = TargetAnimation;
        }
    }
}
