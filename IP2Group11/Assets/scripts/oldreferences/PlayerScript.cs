using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	//variables compromising the gun
	public GameObject gun;
	public GameObject cylinder;
	public GameObject cylinder1;
	public GameObject bullet;
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;
	public GameObject bullet4;
	//variable holding the crosshair
	public GameObject crosshair;
	//variable for the amount of bullets in the player's clip
	public int clip=0;
	//variable for the amount of bullets the player holds outside of the clip
	public int bullets=0;
	//variable for the player's score
	public int score=0;
	//variable for the sound to be played when the player picks up the gun or reloads
	public AudioClip gunPickupSound;
	//variable for the sound to be played when the player picks up ammo
	public AudioClip ammoPickupSound;

	
	// Use this for initialization
	void Start () {
		//checks for the persistent menu music object and destroys it if it exists
		if(GameObject.FindWithTag ("menumusic"))
		{
				Destroy (GameObject.FindWithTag("menumusic"));
		}
		//disables the mouse cursor
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//checks if gun is active
		if(gun.active)
		{
			//checks if gun is being fired
			if(Input.GetButtonDown ("Fire1"))
			{
				//checks if there's ammo in the clip
				if(clip>0)
				{
					//plays the sound of the gun firing
					gun.audio.Play ();
					//performs a raycast
					Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
					RaycastHit hit = new RaycastHit();
					//removes a bullet from the clip
					clip--;
					//checks if the raycast hits
					if(Physics.Raycast (ray, out hit))
					{
						//checks if the raycast hits a target
						if(hit.collider.gameObject.tag=="Target")
						{
							TargetScript targetScript = hit.collider.gameObject.GetComponent<TargetScript>();
							if(targetScript!=null)
							{
								//calls the method to apply force
								targetScript.HitApplyForce(ray.direction, 1000.0f);	
							}
							//adds to the player's score
							score++;
							//checks for the persistent data object
							GameObject gameData=GameObject.Find("GameData");
							if(gameData!=null)
							{
								GameDataScript gameDataScript=gameData.GetComponent<GameDataScript>();
								//updates the player's score in the data object
								gameDataScript.playerScore=score;
							}
						}
					}
				}
				//else the clip is empty
				else
				{
					//plays the audio for an empty clip
					cylinder.audio.Play();
				}
			}
			//checks to see if gun is being reloaded
			if(Input.GetButtonDown ("Reload"))
			{
				//checks to see if we have bullets to reload and that the clip isn't full
				if(bullets>0 && clip<6)
				{
					//a variable holding the amount of bullets to be reloaded
					int reloading=6-clip;
					//moves bullets to the clip
					bullets=bullets-reloading;
					//reloads the clip
					clip=clip+reloading;
					//calls for the reload "animation"
					StartCoroutine (Reload());
				}
			}
		}
	}
	
	void OnGUI()
	{
		//checks for the persistent data object
		GameObject gameData=GameObject.Find ("GameData");
		if(gameData!=null)
		{
			GameDataScript gameDataScript=gameData.GetComponent<GameDataScript>();
			//a label holding the player's name and current score
			GUI.Label(new Rect(10,10,100,40),gameDataScript.playerName+" Score: "+score.ToString());
		}
		if(gun.active)
		{
			//a label displaying the player's clip and ammo 
			GUI.Label(new Rect(Screen.width - 100,Screen.height - 50,100,50),clip.ToString()+" | "+bullets.ToString());
		}
	}
	
	//checks for collisions
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//colliding into a gun
		if (hit.gameObject.tag=="Gun")
		{
			//calls for the gun pickup sound
			StartCoroutine (GunPickup ());
			//destroys the hit object
			Destroy(hit.gameObject);
			//sets all the gun parts active
			gun.active=true;
			cylinder.active=true;
			cylinder1.active=true;
			bullet.active=true;
			bullet1.active=true;
			bullet2.active=true;
			bullet3.active=true;
			bullet4.active=true;
			//enables the crosshair
			crosshair.active=true;
			//puts six bullets in the clip
			clip=6;
		}
		//colliding into ammo
		if (hit.gameObject.tag=="Ammo")
		{
			//calls for the ammo pickup sound
			StartCoroutine (AmmoPickup ());
			//destroys the hit object
			Destroy(hit.gameObject);
			//adds 24 bullets to the player
			bullets=bullets+24;
		}
	}
	
	IEnumerator Reload()
	{
		//disables all the gun parts
		gun.active=false;
		cylinder.active=false;
		cylinder1.active=false;
		bullet.active=false;
		bullet1.active=false;
		bullet2.active=false;
		bullet3.active=false;
		bullet4.active=false;
		//disables the crosshair
		crosshair.active=false;
		//plays the gun pickup (reload) sound and waits until finished
		audio.clip=gunPickupSound;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		//activates all the gun parts
		gun.active=true;
		cylinder.active=true;
		cylinder1.active=true;
		bullet.active=true;
		bullet1.active=true;
		bullet2.active=true;
		bullet3.active=true;
		bullet4.active=true;
		//enables the crosshair
		crosshair.active=true;
	}
	
	//plays the gun pickup sound and waits until finished
	IEnumerator GunPickup()
	{
		audio.clip=gunPickupSound;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
	}
	
	//plays the ammo pickup sound and waits until finished
	IEnumerator AmmoPickup()
	{
		audio.clip=ammoPickupSound;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
	}
}
