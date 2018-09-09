using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Attacker : MonoBehaviour
{

    float currentWalkSpeed = 1f;
    GameObject currentTarget;

    void Start()
    {
        Rigidbody2D myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;
    }

    void Update()
    {
        transform.Translate(Vector3.left * currentWalkSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(gameObject + " ---- Collision!  ----- " + collision.gameObject);
    }

    public void SetWalkSpeed(float speed)
    {
        this.currentWalkSpeed = speed;
    }

    //called from the animator at time of actual atack

    public void StrickeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

}
