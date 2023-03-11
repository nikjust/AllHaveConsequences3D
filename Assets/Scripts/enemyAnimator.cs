using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Animator animator;
    public Enemy enemy;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0 && rb.velocity.z != 0 && rb.velocity.y == 0)
        {
            animator.SetBool("walking", true);
            animator.SetBool("flying", false);
        }
        else if (rb.velocity.x != 0 && rb.velocity.z != 0 && rb.velocity.y != 0)
        {
            animator.SetBool("walking", false);
            animator.SetBool("flying", true);
        }
        else
        {
            animator.SetBool("walking", false);
            animator.SetBool("flying", false);
        }

        if (enemy.Health <= 0)
        {
            animator.SetBool("dead", true);
            rb.isKinematic = true;
            enemy.GetComponent<Collider>().enabled = false;

        }
    }
}
