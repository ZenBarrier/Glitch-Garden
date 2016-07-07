using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    [Range(0f,3f)]
    public float walkingSpeed;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.left * walkingSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D()
    {
        Debug.Log(name);
    }
}
