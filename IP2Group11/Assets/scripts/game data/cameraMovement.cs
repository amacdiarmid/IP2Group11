using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public Vector2 minBound;
	public Vector2 maxBound;

	public float camSpeed;

	public Vector2 mousePos;
	public Vector2 camPos;

	public Canvas mainCan;
	public Canvas buyCan;
	public Canvas upgradeCan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		mousePos = Input.mousePosition;
		camPos = this.gameObject.transform.position;

		mainCan.sortingOrder = -(int)this.gameObject.transform.position.y + 50;
		buyCan.sortingOrder = -(int)buyCan.transform.position.y + 60;
		upgradeCan.sortingOrder = -(int)upgradeCan.transform.position.y + 60;

		if (Input.mousePosition.x < 10 && camPos.x > minBound.x )
		{
			this.gameObject.transform.Translate(new Vector3(-camSpeed, 0, 0) * Time.deltaTime, Space.World);
		}
		if (Input.mousePosition.x > Screen.width - 10 && camPos.x < maxBound.x)
		{
			this.gameObject.transform.Translate(new Vector3(camSpeed, 0, 0) * Time.deltaTime, Space.World);
		}
		if (Input.mousePosition.y < 10 && camPos.y > minBound.y)
		{
			this.gameObject.transform.Translate(new Vector3(0, -camSpeed, 0) * Time.deltaTime, Space.World);
		}
		if (Input.mousePosition.y > Screen.height - 10 && camPos.y < maxBound.y)
		{
			this.gameObject.transform.Translate(new Vector3(0, camSpeed, 0) * Time.deltaTime, Space.World);
		}
	}
}
