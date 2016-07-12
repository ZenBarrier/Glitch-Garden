using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {
    public GameObject[] attackers;

    private GameObject attackerParent;

	// Use this for initialization
	void Start () {
        attackerParent = GameObject.Find("Attackers");
        if (!attackerParent)
        {
            attackerParent = new GameObject("Attackers");
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject attacker in attackers)
        {
            GameObject childAttacker = Instantiate(attacker) as GameObject;
            childAttacker.transform.position = this.transform.position;
            childAttacker.transform.parent = attackerParent.transform;
        }
	}
}
