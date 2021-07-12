using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    Rigidbody2D mRB;
    [SerializeField] private float mFallMultiplier = 2.5f;
    [SerializeField] private float mJumpMultiplier = 2f;
     // Start is called before the first frame update
     void Start()
    {
        mRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mRB.velocity.y>0)
        {
            mRB.gravityScale = mJumpMultiplier;
        }
        else if(mRB.velocity.y<0)
        {
            mRB.gravityScale = mFallMultiplier;
        }
        else
        {
            mRB.gravityScale = 1;
        }
    }
}
