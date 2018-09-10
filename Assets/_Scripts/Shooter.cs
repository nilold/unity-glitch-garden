using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    GameObject projectileParent;

    Animator animator;
    Spawner myLaneSpawner;

    private void Start()
    {
        SetParentObject();
        FindSpawner();
        animator = GetComponent<Animator>();
    }

    private void FindSpawner()
    {
        foreach (Spawner spawner in FindObjectsOfType<Spawner>())
        {
            int myLane = Mathf.RoundToInt(gameObject.transform.position.y);
            int spawnerLane = Mathf.RoundToInt(spawner.transform.position.y);
            if (myLane == spawnerLane)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private void SetParentObject()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update()
    {
        if (isAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool isAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount > 0)
        {
            foreach (Transform child in myLaneSpawner.transform)
            {
                if (child.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
