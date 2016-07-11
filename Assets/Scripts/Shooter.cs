using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, projectileParent;

	private void ShootGun()
    {
        Transform gun = transform.FindChild("Gun");
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity) as GameObject;
        bullet.transform.parent = projectileParent.transform;
    }
}
