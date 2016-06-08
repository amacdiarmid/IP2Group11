using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {

	private int songNo;
	public AudioClip[] song;
	public float volume;
	public static backgroundMusic BKGMusic;
	private AudioSource audioCom;

	void Awake()
	{
		if (BKGMusic == null)
		{
			DontDestroyOnLoad(this);
			BKGMusic = this;
		}
		else if (BKGMusic != this)
		{
			Destroy(this);
		}
		audioCom = this.gameObject.GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		audioCom.clip = song[songNo];
		audioCom.Play ();
		StartCoroutine(songWait());
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void SetChoice(int choice)
	{
		audioCom.clip = song[choice];
		audioCom.Play();
		songNo = choice;
		StopCoroutine(songWait());
		StartCoroutine(songWait());
	}

	public void updateVol(int tempVolume)
	{
		volume = tempVolume;
		audioCom.volume = volume/100;
	}

	IEnumerator songWait()
	{
		yield return new WaitForSeconds(song[songNo].length);
		if (songNo == song.Length)
		{
			SetChoice(0);
		}
		else
		{
			SetChoice(songNo + 1);
		}
	}
}
