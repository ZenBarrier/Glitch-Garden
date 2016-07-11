using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.GetComponent<Attacker>())
        {
            Health health = obj.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}
