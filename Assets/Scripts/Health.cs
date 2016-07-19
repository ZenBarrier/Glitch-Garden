using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;

    private Animator animator;
    private bool hasDamageAnimation;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        hasDamageAnimation = HasParameter("damageTrigger");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DealDamage(float damage)
    {
        health -= damage;
        if (hasDamageAnimation)
        {
            animator.SetTrigger("damageTrigger");
        }
        if (health <= 0)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    bool HasParameter(string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
            {
                return true;
            }
        }
        return false;
    }
}
