using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

	public Transform target;
	Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate ()
	{
		if (target != null && target.position.y > transform.position.y) {
			targetPos = target.position;
			targetPos.x = transform.position.x;
			targetPos.z = transform.position.z;
			transform.position = Vector3.Slerp (transform.position, targetPos, 0.4f);
		}
	}
}
