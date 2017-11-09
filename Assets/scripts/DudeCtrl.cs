using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class DudeCtrl : MonoBehaviour {
	
	Rigidbody2D rb;
	float movement = 0f;
	
	public float movementSpeed = 10f;
	
    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;  //sideways input
	}
    
    // Update is called once per frame
    void FixedUpdate () {
		 Vector2 velocity = rb.velocity;						//sideways movement
		 velocity.x = movement;
		 rb.velocity = velocity;
    }

	void OnBecameInvisible() {
        Destroy(gameObject);
		SceneMngr s = new SceneMngr();
		s.Restart();
     }
}