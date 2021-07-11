using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D Rigidbody2D;

    public Collider2D[] hitEnemies;
    public LayerMask layerMask;
    public Transform hitIndicator;
    public float hitRange = 0.5f;
    public int knockbackX = 1;
    public int knockbackY = 1;

    // Update is called once per frame

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {


        animator.SetTrigger("Attack");
        hitEnemies= Physics2D.OverlapCircleAll(hitIndicator.position, hitRange, layerMask);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(Rigidbody2D.velocity.x>0)
            {
                var knockback = new Vector2(knockbackX, knockbackY);
                Debug.Log(enemy.attachedRigidbody.position);
                Debug.Log("facing right");
                enemy.attachedRigidbody.AddForce(knockback*100);


            }
            else if(Rigidbody2D.velocity.x < 0)
            {
                var knockback = new Vector2(-knockbackX, knockbackY);
                Debug.Log(enemy.attachedRigidbody.position);
                Debug.Log("facing left");
                enemy.attachedRigidbody.AddForce(knockback * 100);
            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitIndicator.position, hitRange);
    }

}
