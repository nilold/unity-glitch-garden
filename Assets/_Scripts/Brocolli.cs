using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brocolli : MonoBehaviour
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
        else
        {
            animator.SetBool("isAttacking", true);
            attacker.Attack(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("isAttacking", false);
    }
}
