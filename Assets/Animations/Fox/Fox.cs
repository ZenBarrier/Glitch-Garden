using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator foxAnimator;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        foxAnimator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.GetComponent<Defender>())
        {
            if (obj.GetComponent<Gravestone>())
            {
                foxAnimator.SetTrigger("jumpTrigger");
            }
            else
            {
                foxAnimator.SetBool("isAttacking", true);
                attacker.Attack(obj);
            }
        }
    }
}
