using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {
    public GameObject[] attackers;

	
	// Update is called once per frame
	void Update () {
        foreach (GameObject attacker in attackers)
        {
            if (isTimeToSpawn(attacker))
            {
                SpawnAttacker(attacker);
            }
        }
	}

    void SpawnAttacker(GameObject attacker)
    {
        GameObject childAttacker = Instantiate(attacker) as GameObject;
        childAttacker.transform.position = this.transform.position;
        childAttacker.transform.parent = this.transform;
    }

    bool isTimeToSpawn(GameObject thisAttacker)
    {
        float attackerMean = thisAttacker.GetComponent<Attacker>().spawnRate;
        float attackersPerSec = 1 / attackerMean;
        float probabilty = Time.deltaTime * attackersPerSec / 5;

        return (Random.value < probabilty);
    }
}
