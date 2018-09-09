using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{

    Animator animator;
    Attacker attacker;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Defender>())
        {
            return;
        }

        if (collision.GetComponent<Stone>())
        {
            animator.SetBool("jumpTrigger", true);
        }
        else
        {
            attacker.Attack(collision.gameObject);
            animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("isAttacking", false);
        if (collision.GetComponent<Stone>())
        {
            animator.SetBool("jumpTrigger", false);
        }
    }
}
