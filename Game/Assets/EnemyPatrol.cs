using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float mVelocity;
    public Transform mGroundDetection;
    public Transform mEnemy;
    
    private float mDistance = 2;
    private Vector2 velocity;
    private Vector3 facing;
    Rigidbody2D mRB;
    AIPathfinding mAIPathfinding;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LOFDIOJFDKLSJFKLDS");
        mRB = GetComponent<Rigidbody2D>();
        mAIPathfinding = GetComponent<AIPathfinding>();
        Debug.Log(mRB);
        mAIPathfinding.enabled = false;
        velocity = new Vector2(mVelocity, mRB.velocity.y);
        facing = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D groundinfo = Physics2D.Raycast(mGroundDetection.position, Vector2.down, mDistance);
        Debug.DrawRay(mGroundDetection.position, Vector2.down * (mDistance), Color.green);

        if (groundinfo.collider == false)
        {
            facing.x *= -1;
            velocity.x *= -1;
        }
        mEnemy.localScale = facing;
        mRB.velocity = velocity;

    }
}
