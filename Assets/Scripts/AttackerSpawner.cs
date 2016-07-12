using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {
    public GameObject[] attackers;

	
	// Update is called once per frame
	void Update () {
        foreach (GameObject attacker in attackers)
        {
            GameObject childAttacker = Instantiate(attacker) as GameObject;
            childAttacker.transform.position = this.transform.position;
            childAttacker.transform.parent = this.transform;
        }
	}
}
