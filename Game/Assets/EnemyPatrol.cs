using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float mVelocity;
    public bool mMovingRight = true;
    public Transform mGroundDetection;
    
    private float mDistance = 2;
    
    Rigidbody2D mRB;
    AIPathfinding mAIPathfinding;

    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody2D>();
        mAIPathfinding = GetComponent<AIPathfinding>();
        mAIPathfinding.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D groundinfo = Physics2D.Raycast(mGroundDetection.position, Vector2.down, mDistance);
        Debug.DrawRay(mGroundDetection.position, Vector2.down * (mDistance), Color.green);
        if (mMovingRight == true)
        {
            mRB.velocity = new Vector2(mVelocity, mRB.velocity.y);
        }
        else
        {
            mRB.velocity = new Vector2(-mVelocity, mRB.velocity.y);
        }
        if (groundinfo.collider == false)
        {
            if (mMovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mMovingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mMovingRight = true;
            }
        }

    }
}
