using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;

    private GameObject projectileParent;

    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

	private void ShootGun()
    {
        Transform gun = transform.FindChild("Gun");
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity) as GameObject;
        bullet.transform.parent = projectileParent.transform;
    }
}
