using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public float x = 0f;
	public float y = 0f;
	public float z = 0f;
	private Vector3 direction;
	private float speed;
	private float origin;
	// Use this for initialization
	void Start () {
		if (x != 0) {
			direction = Vector3.right;
			speed = x;
		}
		if (y != 0) {
			direction = Vector3.up;
			speed = y;
		}
		if (z != 0) {
			direction = Vector3.forward;
			speed = z;
		}
		origin = speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name == "left") {
			Debug.Log ("set speed " + speed);
		}

		transform.Translate (direction*speed*Time.deltaTime);
	}

	public void Stop(){
		speed = 0;
	}
	public void Recovery(){
		speed = -origin;
	}
	public void Restart(){
		speed = origin;
	}
}
