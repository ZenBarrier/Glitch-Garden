using UnityEngine;
using System.Collections;

public class Attackers : MonoBehaviour {

    [Range(-1f,3f)]
    public float walkingSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.left * walkingSpeed * Time.deltaTime);
	}
}
