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
		load();
	}

	void load()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			basicLevelActive = PlayerPrefs.GetInt("basicLevelActive");
			basicLevelScore[0] = PlayerPrefs.GetInt("level1");
			basicLevelScore[1] = PlayerPrefs.GetInt("level2");
			basicLevelScore[2] = PlayerPrefs.GetInt("level3");
			basicLevelScore[3] = PlayerPrefs.GetInt("level4");
			basicLevelScore[4] = PlayerPrefs.GetInt("level5");
		}
	}

	public void save()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			PlayerPrefs.SetInt("basicLevelActive", basicLevelActive);
			PlayerPrefs.SetInt("level1", basicLevelScore[0]);
			PlayerPrefs.SetInt("level2", basicLevelScore[1]);
			PlayerPrefs.SetInt("level3", basicLevelScore[2]);
			PlayerPrefs.SetInt("level4", basicLevelScore[3]);
			PlayerPrefs.SetInt("level5", basicLevelScore[4]);
		}
	}
}
