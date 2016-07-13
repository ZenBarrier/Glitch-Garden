using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;

    private GameObject projectileParent;
    private GameObject myLane;
    private Animator animator;

    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        FindMyLane();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void FindMyLane()
    {
        GameObject Lanes = GameObject.Find("Spawners");
        if (!Lanes)
        {
            Debug.LogError("No Spawners found.");
            return;
        }
        foreach (Transform child in Lanes.transform)
        {
            if(child.position.y == this.transform.position.y)
            {
                myLane = child.gameObject;
            }
        }
    }

    bool isAttackerInLane()
    {
        if(myLane.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	private void ShootGun()
    {
        Transform gun = transform.FindChild("Gun");
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity) as GameObject;
        bullet.transform.parent = projectileParent.transform;
    }
}
