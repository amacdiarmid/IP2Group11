using UnityEngine;
using System.Collections;

public class mainMenuData : menuData {

	public GameObject main;
	public GameObject levelSelect;
	public GameObject options;
	public GameObject credits;

	// Use this for initialization
	void Start () {

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
		}
		else if (menu == "level select")
		{
			main.SetActive(false);
			levelSelect.SetActive(true);
			options.SetActive(false);
			credits.SetActive(false);
		}
		else if (menu == "options")
		{
			main.SetActive(false);
			levelSelect.SetActive(false);
			options.SetActive(true);
			credits.SetActive(false);
		}
		else if (menu == "credits")
		{
			main.SetActive(false);
			levelSelect.SetActive(false);
			options.SetActive(false);
			credits.SetActive(true);
		}
		else
		{
			Debug.Log("menu change error");
		}
	}
}
