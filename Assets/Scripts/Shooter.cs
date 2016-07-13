using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile;

    private GameObject projectileParent;
    private AttackerSpawner myLane;
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
        if (IsAttackerAhead())
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
        AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            if(spawner.transform.position.y == this.transform.position.y)
            {
                myLane = spawner;
                return;
            }
        }
        Debug.LogError("Spawner not found.");
    }

    bool IsAttackerAhead()
    {
        foreach (Transform attacker in myLane.transform)
        {
            if(attacker.position.x > this.transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

	private void ShootGun()
    {
        Transform gun = transform.FindChild("Gun");
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity) as GameObject;
        bullet.transform.parent = projectileParent.transform;
    }
}
