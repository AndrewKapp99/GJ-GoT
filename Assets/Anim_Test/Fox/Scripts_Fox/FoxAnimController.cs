using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAnimController : MonoBehaviour
{

    private Animator _anim;
    //private FoxController _foxController;

    void Start()
    {
        _anim = GetComponent<Animator>();
        //_foxController = GameObject.FindGameObjectWithTag("Player").GetComponent<FoxController>();
    }

    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider playAnimTrigger)
    {

        /* As the fox passes over different labelled hidden objects, the appropriate animation will be triggered. We could either do it by tag or name,
         * I think it's going to be a ton of tags so maybe by name is better.
         */

        if(playAnimTrigger.CompareTag("Jump Trigger"))
        {
            Debug.Log("hit jump anim trigger");
            _anim.SetBool("walkBool", false);
            _anim.SetBool("jumpBool", true);
        }
            

        if (playAnimTrigger.CompareTag("Walk Trigger"))
            _anim.SetBool("walkBool", true);
    }
}
