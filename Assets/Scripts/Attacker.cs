using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("How often to spawn in seconds")]
    public float spawnRate;
    
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    void OnTriggerEnter2D()
    {
        Debug.Log(name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //called by attack animation
    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name +" caused damage: "+ damage);
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
        //Sets target for Strike. Strike called by animator.
        currentTarget = obj;
    }
}
