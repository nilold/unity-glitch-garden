using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        if(attacker){
            Health health = collision.GetComponent<Health>();
            if(health){
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
