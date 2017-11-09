using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float jumpForce = 5f;

    // Use this for initialization
    void Start () {
		
    }
    
    // Update is called once per frame
    void Update () {
    	
    }
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.tag == "Player") {
			if (collision.relativeVelocity.y >= 0.0f) {		
				Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D> ();		// pushing player in upwards direction
				if (rb != null) {
					Vector2 velocity = rb.velocity;
					velocity.y = jumpForce; 
					rb.velocity = velocity;
				}
			}
		}

		if (collision.collider.tag == "death") {							
			Debug.Log("Destroyed!");
			Destroy (gameObject);
		}
	}
}