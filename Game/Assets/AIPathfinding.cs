using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathfinding : MonoBehaviour
{
    public Transform mTarget;
    public Transform mEnemy;

    public Transform mEnemyGFX;

    public float mSpeed = 400f;
    public float mNextWaypointDistance = 3f;

    Path mPath;
    int mCurrentWaypoint = 0;
    bool mReachedEndOfPath = false;

    Seeker mSeeker;
    Rigidbody2D mRB;

    void Start()
    {
        mSeeker = GetComponent<Seeker>();
        mRB = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    private void UpdatePath() {
        if (mSeeker.IsDone()) {
            mSeeker.StartPath(mRB.position, mTarget.position, OnPathComplete);
        }
        
    }

    private void OnPathComplete(Path p) {
        if (!p.error) {
            mPath = p;
            mCurrentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (mPath == null) {
            return;
        }
        if (mCurrentWaypoint >= mPath.vectorPath.Count)
        {
            mReachedEndOfPath = true;
            return;
        }
        else {
            mReachedEndOfPath = false;
                }
        Vector2 direction = ((Vector2)mPath.vectorPath[mCurrentWaypoint] - mRB.position).normalized;
        Vector2 force = direction * mSpeed * Time.deltaTime;

        mRB.AddForce(force);

        float distance = Vector2.Distance(mRB.position, mPath.vectorPath[mCurrentWaypoint]);

        if (distance < mNextWaypointDistance) {
            mCurrentWaypoint++;
        }
        if (direction.x >= 0.1f)
        {
            mEnemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direction.x <= -0.1)
        {
            mEnemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
