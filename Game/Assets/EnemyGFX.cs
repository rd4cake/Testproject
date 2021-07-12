using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath mAIPath;
    //Flips the enemy sprite based on which direction it is facing
    void Update()
    {
        if (mAIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (mAIPath.desiredVelocity.x <= -0.01) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
