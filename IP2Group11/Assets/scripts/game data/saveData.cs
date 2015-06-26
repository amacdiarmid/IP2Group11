using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
#if UNITY_METRO && !UNITY_EDITOR
	using legacySystem.IO;
#else
	using System.IO;
#endif

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
#if UNITY_WEBPLAYER || UNITY_WEBGL
			basicLevelActive = PlayerPrefs.GetInt("basicLevelActive");
			basicLevelScore[0] = PlayerPrefs.GetInt("level1");
			basicLevelScore[1] = PlayerPrefs.GetInt("level2");
			basicLevelScore[2] = PlayerPrefs.GetInt("level3");
			basicLevelScore[3] = PlayerPrefs.GetInt("level4");
			basicLevelScore[4] = PlayerPrefs.GetInt("level5");
#else
			if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
				playerData data = (playerData)bf.Deserialize(file);
				file.Close();

				basicLevelScore = data.basicLevelScore;
				basicLevelActive = data.basicLevelActive;
			}
#endif
	}

	public void save()
	{
#if UNITY_WEBPLAYER || UNITY_WEBGL
			PlayerPrefs.SetInt("basicLevelActive", basicLevelActive);
			PlayerPrefs.SetInt("level1", basicLevelScore[0]);
			PlayerPrefs.SetInt("level2", basicLevelScore[1]);
			PlayerPrefs.SetInt("level3", basicLevelScore[2]);
			PlayerPrefs.SetInt("level4", basicLevelScore[3]);
			PlayerPrefs.SetInt("level5", basicLevelScore[4]);
#else
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath + "/gameData.dat");
			playerData data = new playerData();
			data.basicLevelScore = basicLevelScore;
			data.basicLevelActive = basicLevelActive;
			bf.Serialize(file, data);
			file.Close();
#endif	
	}
}

[Serializable]
class playerData
{
	public List<int> basicLevelScore;
	public int basicLevelActive;
}
