using UnityEngine;
using System.Collections;

public class mouseClick : MonoBehaviour {

	public AudioClip click;

	public float volume;
	public static mouseClick mouseCLK;
	private AudioSource audioCom;

	void Awake()
	{
		if (mouseCLK == null)
		{
			DontDestroyOnLoad(this);
			mouseCLK = this;
		}
		else if (mouseCLK != this)
		{
			Destroy(this);
		}
		audioCom = this.gameObject.GetComponent<AudioSource>();
		audioCom.clip = click;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);	
	}
	
	public void updateVol(int tempVolume)
	{
		volume = tempVolume;
		audioCom.volume = volume/100;
	}

	public void playClick()
	{
		audioCom.Play();
	}
}
