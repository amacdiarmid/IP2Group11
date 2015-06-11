using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class saveData : MonoBehaviour {

	public static saveData saveControl;

	public List<int> basicLevelScore;
	public int basicLevelActive;

	// Use this for initialization
	void Awake () {
		if (saveControl == null)
		{
			DontDestroyOnLoad(this);
			saveControl = this;
		}
		else if (saveControl != this)
		{
			Destroy(this);
		}
	}
}
