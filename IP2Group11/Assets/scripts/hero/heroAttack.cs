using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class heroAttack : MonoBehaviour {

	//the range for each attack
	public float autoAttackRange;
	public float medAttackRange;
	public float heavyAttackRange;
	public float AOERange;
	//the cooldown on each attack
	public float autoCooldown;
	public float medCooldown;
	public float heavyCooldown;
	public float AOECooldown;
	public float AOELength;
	//storage for game time 
	private float medGameTime;
	private float heavyGameTime;
	private float AOEGameTime;
	//the damage for each attack
	public int autoDamage;
	public int medDamage;
	public int heavyDamage;
	public int AOEDamage;
	//if an ability can be used
	private bool autoCanUse;
	private bool medCanUse;
	private bool heavyCanUse;
	private bool AOECanUse;
	public GameObject AOEData;
	private GameObject tempAOEData;
	public AudioClip[] sounds;
	private heroMovement HeroMovement;
	private Animator animator;
	//button panels
	public RectTransform medPanel;
	public RectTransform heavyPanel;
	public RectTransform AOEPanel;
	//slash gameobject
	public slashData slashData;

	// Use this for initialization
	void Start () {
		//set all the abilities to true so they can be used
		autoCanUse = true;
		medCanUse = true;
		heavyCanUse = true;
		AOECanUse = true;
		HeroMovement = this.gameObject.GetComponent<heroMovement>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (HeroMovement.move == false)
		{
			//the medium attack button has been called
			if (Input.GetButtonUp("Medium Attack"))
			{	
				medAttack();
			}
			//the Heavy attack button has been called
			else if (Input.GetButtonUp("Heavy Attack"))
			{
				heavyAttack();
			}
			//the AOE attack button has been called
			else if (Input.GetButtonUp("AOE Attack"))
			{
				AOEAttack();
			}
			else
			{
				//the no attack has been called so the auto attack can be called if it is ready
				if (autoCanUse == true)
				{
					autoCanUse = false;
					autoAttack();
				}
			}
		}
		if (medCanUse == false)
		{
			float time = Time.time - medGameTime;
			if (time >= medCooldown)
			{
				medCanUse = true;
				medPanel.gameObject.SetActive(false);
			}
			else
			{
				medPanel.localScale = new Vector3(1 - (time / medCooldown), 1, 1);
			}
		}
		if (heavyCanUse == false)
		{
			float time = Time.time - heavyGameTime;
			if (time >= heavyCooldown)
			{
				heavyCanUse = true;
				heavyPanel.gameObject.SetActive(false);
			}
			else
			{
				heavyPanel.localScale = new Vector3(1 - (time / heavyCooldown), 1, 1);
			}
		}
		if (AOECanUse == false)
		{
			float time = Time.time - AOEGameTime;
			if (time >= AOECooldown)
			{
				AOECanUse = true;
				AOEPanel.gameObject.SetActive(false);
			}
			else
			{
				AOEPanel.localScale = new Vector3(1 - (time / AOECooldown), 1, 1);
			}
		}
		if (autoCanUse == false)
		{
			float time = Time.time;
			if (time >= autoCooldown)
			{
				autoCanUse = true;
			}
		}
	}

	/// <summary>
	/// this is called if the auto attack has been slected in the update
	/// </summary>
	void autoAttack()
	{
		GetComponent<AudioSource>().clip = sounds[0];
		GetComponent<AudioSource>().Play();
		animator.SetTrigger("auto");
	}

	/// <summary>
	/// this is called if the medium attack has been slected in the update
	/// </summary>
	public void medAttack()
	{
		if (medCanUse == true)
		{
			medCanUse = false;
			medPanel.gameObject.SetActive(true);
			medPanel.localScale = new Vector3(1, 1, 1);
			medGameTime = Time.time;
			GetComponent<AudioSource>().clip = sounds[0];
			GetComponent<AudioSource>().Play();
			animator.SetTrigger("med");
		}		
	}

	/// <summary>
	/// this is called if the heavy attack has been slected in the update
	/// </summary>
	/// 
	public void heavyAttack()
	{
		if (heavyCanUse == true)
		{
			heavyCanUse = false;
			heavyPanel.gameObject.SetActive(true);
			heavyPanel.localScale = new Vector3(1, 1, 1);
			heavyGameTime = Time.time;
			GetComponent<AudioSource>().clip = sounds[0];
			GetComponent<AudioSource>().Play();
			animator.SetTrigger("heavy");
		}
	}
	/// <summary>
	/// this is called if the AOE attack has been slected in the update
	/// the paramiter is used to determine if this is the first or second call to this method
	/// </summary>
	public void AOEAttack()
	{
		if (AOECanUse == true)
		{
			AOECanUse = false;
			GetComponent<AudioSource>().clip = sounds[1];
			GetComponent<AudioSource>().Play();
			AOEPanel.gameObject.SetActive(true);
			AOEPanel.localScale = new Vector3(1, 1, 1);
			AOEGameTime = Time.time;
			tempAOEData = Instantiate(AOEData, this.transform.position, Quaternion.identity) as GameObject;
			tempAOEData.GetComponent<AOEData>().stats(AOERange, AOEDamage);
		}
	}
}
