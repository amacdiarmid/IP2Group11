using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class mainMenuData : menuData
{

	public GameObject main;
	public GameObject levelSelect;
	public GameObject options;
	public GameObject credits;
	public GameObject music;

	public List<GameObject> webHide;
	public List<GameObject> webShow;

	public Slider qualitySlide;
	public Text qualityText;
	public Slider masterSlide;
	public Text masterText;
	public Slider SFXSlider;
	public Text SFXText;
	public Slider musicSlider;
	public Text musicText;

	private int hasPlayed;

	// Use this for initialization
	void Start()
	{
#if UNITY_WEBPLAYER || UNITY_WEBGL
		foreach (var item in webHide)
		{
			item.SetActive(false);
		}
		foreach (var item in webShow)
		{
			item.SetActive(true);
		} 	
		qualitySlide.value = 0;
		masterSlide.value = 100;
		SFXSlider.value = 100;
		musicSlider.value = 100
#endif

#if !UNITY_WEBPLAYER || !UNITY_WEBGL
		hasPlayed = PlayerPrefs.GetInt("hasPlayed");
		if (hasPlayed == 0)
		{
			qualitySlide.value = 0;
			masterSlide.value = 100;
			SFXSlider.value = 100;
			musicSlider.value = 100;
			masterText.text = "master volume: " + (int)masterSlide.value + " %";
			SFXText.text = "SFX volume: " + (int)SFXSlider.value + " %";
			musicText.text = "music volume: " + (int)musicSlider.value + " %";
			qualityText.text = "quality setting: " + QualitySettings.names[QualitySettings.GetQualityLevel()];
			hasPlayed = 1;
			PlayerPrefs.SetInt("hasPlayed", hasPlayed);

		}
		else
		{
			qualitySlide.value = PlayerPrefs.GetInt("qualityLevel");
			masterSlide.value = PlayerPrefs.GetInt("masterVol");
			SFXSlider.value = PlayerPrefs.GetInt("SFXVol");
			musicSlider.value = PlayerPrefs.GetInt("musicVol");
			masterText.text = "master volume: " + (int)masterSlide.value + " %";
			SFXText.text = "SFX volume: " + (int)SFXSlider.value + " %";
			musicText.text = "music volume: " + (int)musicSlider.value + " %";
			qualityText.text = "quality setting: " + QualitySettings.names[QualitySettings.GetQualityLevel()];
		}
#endif
		
	}

	// Update is called once per frame
	public void changeMenu(string menu)
	{
		if (menu == "main")
		{
			main.SetActive(true);
			levelSelect.SetActive(false);
			options.SetActive(false);
			credits.SetActive(false);
			music.SetActive(false);
		}
		else if (menu == "level select")
		{
			main.SetActive(false);
			levelSelect.SetActive(true);
			options.SetActive(false);
			credits.SetActive(false);
			music.SetActive(false);
		}
		else if (menu == "options")
		{
			main.SetActive(false);
			levelSelect.SetActive(false);
			options.SetActive(true);
			credits.SetActive(false);
			music.SetActive(false);
		}
		else if (menu == "credits")
		{
			main.SetActive(false);
			levelSelect.SetActive(false);
			options.SetActive(false);
			credits.SetActive(true);
			music.SetActive(false);
		}
		else if (menu == "music")
		{
			main.SetActive(false);
			levelSelect.SetActive(false);
			options.SetActive(false);
			credits.SetActive(false);
			music.SetActive(true);
		}
		else
		{
			Debug.Log("menu change error");
		}
		mouseClick.mouseCLK.playClick();
	}

	public void setQuality()
	{
		QualitySettings.SetQualityLevel((int)qualitySlide.value);
		qualityText.text = "quality setting: " + QualitySettings.names[QualitySettings.GetQualityLevel()];
#if !UNITY_WEBPLAYER || !UNITY_WEBGL
		PlayerPrefs.SetInt("qualityLevel", (int)qualitySlide.value);
#endif
	}

	public void setMaster()
	{
		SFXSlider.value = masterSlide.value;
		musicSlider.value = masterSlide.value;
		masterText.text = "master volume: " + (int)masterSlide.value + " %";
#if !UNITY_WEBPLAYER || !UNITY_WEBGL
		PlayerPrefs.SetInt("masterVol", (int)masterSlide.value);
#endif
	}

	public void setSFX()
	{
		mouseClick.mouseCLK.updateVol((int)SFXSlider.value);
		SFXText.text = "SFX volume: " + (int)SFXSlider.value + " %";
#if !UNITY_WEBPLAYER || !UNITY_WEBGL
		PlayerPrefs.SetInt("SFXVol", (int)SFXSlider.value);
#endif
	}

	public void setMusic()
	{
		backgroundMusic.BKGMusic.updateVol((int)musicSlider.value);
		musicText.text = "music volume: " + (int)musicSlider.value + " %";
#if !UNITY_WEBPLAYER || !UNITY_WEBGL
		PlayerPrefs.SetInt("musicVol", (int)musicSlider.value);
#endif
	}

	public void openBlog()
	{
		Application.OpenURL("https://amacdiarmid.wordpress.com/");
	}

	public void openTwitter()
	{
		Application.OpenURL("https://twitter.com/amacdiarmid01");
	}

	public void openIncomp()
	{
		Application.OpenURL("http://incompetech.com/wordpress/");
	}

	public void ChangeSong(int number)
	{
		backgroundMusic.BKGMusic.SetChoice(number);
		mouseClick.mouseCLK.playClick();
	}
}
