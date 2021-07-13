using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float velocity;
    public float distance;
    public bool movingright = true;
    public Transform grounddetection;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D groundinfo = Physics2D.Raycast(grounddetection.position, Vector2.down, distance);
        Debug.DrawRay(grounddetection.position, Vector2.down * (distance), Color.green);
        if (movingright == true)
        {
            rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-velocity, rb2d.velocity.y);
        }
        if (groundinfo.collider == false)
        {
            if (movingright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }

    }
}
