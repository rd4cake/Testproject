using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMode : MonoBehaviour
{
    void Start()
    {

    }

    void FixedUpdate()
    {



    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {

            target.gameObject.GetComponent<AIPath>().enabled = false;
            target.gameObject.GetComponent<EnemyMode>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {

            target.gameObject.GetComponent<AIPath>().enabled = true;
            target.gameObject.GetComponent<EnemyMode>().enabled = false;
        }
    }
}