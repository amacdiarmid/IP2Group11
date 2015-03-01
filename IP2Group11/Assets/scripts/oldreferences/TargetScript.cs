using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Plays audio clip and destroys object when finished
	IEnumerator PlaySoundAndRemove()
	{
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		Destroy (gameObject);
	}
	//When called adds physics to a rigid force according to the parameters received and calls the above method	
	public void HitApplyForce(Vector3 direction, float force)
	{
		rigidbody.AddForce(direction*force);
		StartCoroutine(PlaySoundAndRemove());
	}
}
