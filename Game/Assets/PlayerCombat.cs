using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D Rigidbody2D;

    public LayerMask layerMask;
    public Transform hitIndicator;
    public Transform mTransfrom;
    public int knockbackX;
    public int knockbackY;

    private Collider2D[] hitEnemies;
    private float hitRange = 1.2f;

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
        CheckHit();

    }
    public void CheckHit() {
        hitEnemies = Physics2D.OverlapCircleAll(hitIndicator.position, hitRange, layerMask);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (mTransfrom.localScale.x > 0)
            {
                var knockback = new Vector2(knockbackX, knockbackY);
                Debug.Log(enemy.attachedRigidbody.position);
                Debug.Log("facing right");
                enemy.attachedRigidbody.AddForce(knockback * 100);
            }
            else if (mTransfrom.localScale.x < 0)
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
