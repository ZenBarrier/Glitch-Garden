using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{

    private Animator lizardAnimator;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        lizardAnimator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.GetComponent<Defender>())
        {
            lizardAnimator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
