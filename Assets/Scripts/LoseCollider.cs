using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    public LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Attacker>())
        {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
