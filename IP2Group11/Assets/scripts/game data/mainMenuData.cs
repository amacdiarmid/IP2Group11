using UnityEngine;
using System.Collections;

public class mainMenuData : menuData {

	public GameObject mainCam;
	public GameObject optionsCam;
	public GameObject creditsCam;

	

	// Use this for initialization
	void Start () {
		mainCam.SetActive(true);
		optionsCam.SetActive(false);
		creditsCam.SetActive(false);
	}
	
	// Update is called once per frame
	public void changeMenu(string menu)
	{
		if (menu == "main")
		{
			mainCam.SetActive(true);
			optionsCam.SetActive(false);
			creditsCam.SetActive(false);
		}
		else if (menu == "options")
		{
			optionsCam.SetActive(true);
			mainCam.SetActive(false);
			creditsCam.SetActive(false);
		}
		else if (menu == "credits")
		{
			creditsCam.SetActive(true);
			optionsCam.SetActive(false);
			mainCam.SetActive(false);
		}
		else
		{
			Debug.Log("menu change error");
		}
	}
}
