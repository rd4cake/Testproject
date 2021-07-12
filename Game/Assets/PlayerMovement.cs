using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D mController;

    public float mRunSpeed;
    private float mHorizontalMovement;
    private bool mJump;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mHorizontalMovement = Input.GetAxisRaw("Horizontal")*mRunSpeed;
        if (Input.GetButton("Jump")) {
            mJump = true;
        }
    }

    private void FixedUpdate()
    {
        
        mController.Move(mHorizontalMovement*Time.fixedDeltaTime,false,mJump);
        mJump = false;
    }
}
