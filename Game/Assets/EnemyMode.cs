using UnityEngine;
using Pathfinding;

public class EnemyMode : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GroundEnemy")
        {
            target.gameObject.GetComponent<AIPathfinding>().enabled = true;
            target.gameObject.GetComponent<EnemyPatrol>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "GroundEnemy")
        {
            target.gameObject.GetComponent<AIPathfinding>().enabled = false;
            target.gameObject.GetComponent<EnemyPatrol>().enabled = true;
        }
    }
}