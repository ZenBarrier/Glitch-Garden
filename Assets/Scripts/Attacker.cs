using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
    
    private float currentSpeed;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D()
    {
        Debug.Log(name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name +" caused damage: "+ damage);
    }

    public void StartAttack(GameObject obj)
    {

    }
}
