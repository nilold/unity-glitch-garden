using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileParent;
    [SerializeField] GameObject gun;

    private void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent){
            projectileParent = new GameObject("Projectiles");
        }
    }

    void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
