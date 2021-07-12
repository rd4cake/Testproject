using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float jumpMultiplier = 2f;
     // Start is called before the first frame update
     void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rigidbody2D.velocity.y>0)
        {
            rigidbody2D.gravityScale = jumpMultiplier;
        }
        else if(rigidbody2D.velocity.y<0)
        {
            rigidbody2D.gravityScale = fallMultiplier;
        }
        else
        {
            rigidbody2D.gravityScale = 1;
        }
    }
}
