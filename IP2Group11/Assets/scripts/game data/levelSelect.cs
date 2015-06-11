using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class levelSelect : MonoBehaviour {

	public List<Button> buttons;
	public List<Sprite> levelSprites;
	public Image imageBox;
	public Text textBox;
	public RectTransform levelMessage;
	public RectTransform scoreMessage;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < saveData.saveControl.basicLevelActive; i++)
		{
			buttons[i].gameObject.SetActive(true);
		}
		imageBox.sprite = levelSprites[0];
		textBox.text = "level " + (0 + 1) + ": " + saveData.saveControl.basicLevelScore[0] + "/3";
		if (saveData.saveControl.basicLevelActive == buttons.Count)
		{
			levelMessage.gameObject.SetActive(true);
		}
		if (saveData.saveControl.basicLevelScore.Sum() == buttons.Count*3 )
		{
			scoreMessage.gameObject.SetActive(true);
		}
	}

	public void showLevel(int levelID)
	{
		imageBox.sprite = levelSprites[levelID];
		textBox.text = "level " + (levelID + 1) + ": " + saveData.saveControl.basicLevelScore[levelID] + "/3";
	}
}
