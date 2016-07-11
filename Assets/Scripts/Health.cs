using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DealDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("damageTrigger");
        if (health < 0)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
