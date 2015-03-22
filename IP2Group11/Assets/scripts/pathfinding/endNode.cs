using UnityEngine;
using System.Collections;
using System.Linq;

public class endNode : pathNodes {

	// Use this for initialization
	void Start () 
	{
		Up = true;
		Down = true;
		Left = true;
		Right = true;
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
			Debug.Log("end return true");
			return true;
		}
		else
		{
			Debug.Log("end return fale");
			return false;	
		} 
	}
}