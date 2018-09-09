using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizzard : MonoBehaviour
{

    Animator animator;
    Attacker attacker;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

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
