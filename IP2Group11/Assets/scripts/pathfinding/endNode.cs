using UnityEngine;
using System.Collections;
using System.Linq;

public class endNode : pathNodes {

	public WaveData waveData;

	// Use this for initialization
	void Start () 
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
		waveData = GameObject.Find("Game Data").GetComponent<WaveData>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool recieveRay()
	{
		if (done == false)
		{
			done = true;
			path.Add(this.transform.position);
			path = path.Distinct().ToList();
			Debug.Log("end path");
			return true;
		}
		else
		{
			return false;	
		} 
	}
}
