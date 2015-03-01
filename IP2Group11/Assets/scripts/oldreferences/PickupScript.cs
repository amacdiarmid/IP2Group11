using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {
	
	//variable for the rotation speed of the object
	public float rotationSpeed = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rotates the object
		transform.Rotate (Vector3.up*Time.deltaTime*rotationSpeed);
	}
}
