using UnityEngine;
using System.Collections;

public class EndSceneTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//When a game object tagged as "Player" collides, start coroutine
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			StartCoroutine(EndScene());	
		}
	}
	//Play audio clip and load level when finished
	IEnumerator EndScene()
	{
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		Application.LoadLevel("EndScene");
	}
}
