using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Attacker>()){
            GetComponent<Animator>().SetBool("isAttacked", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            GetComponent<Animator>().SetBool("isAttacked", false);
        }
    }
}
