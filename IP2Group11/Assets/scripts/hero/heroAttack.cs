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
	private AudioSource audioCom;
	private heroMovement HeroMovement;
	private Animator animator;
	//button panels
	public RectTransform medPanel;
	public RectTransform heavyPanel;
	public RectTransform AOEPanel;

	// Use this for initialization
	void Start () {
		//set all the abilities to true so they can be used
		autoCanUse = true;
		medCanUse = true;
		heavyCanUse = true;
		AOECanUse = true;
		HeroMovement = this.gameObject.GetComponent<heroMovement>();
		animator = GetComponent<Animator>();
		audioCom = this.gameObject.GetComponent<AudioSource>();
		audioCom.volume = mouseClick.mouseCLK.volume / 100;
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
		audioCom.volume = mouseClick.mouseCLK.volume / 100;
		//send a raycast NE to see if there is a creep
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			audioCom.clip = sounds[0];
			audioCom.Play();
			hitNE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
			animator.SetTrigger("auto");
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				audioCom.clip = sounds[0];
				audioCom.Play();
				hitSE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
				animator.SetTrigger("auto");
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					audioCom.clip = sounds[0];
					audioCom.Play();
					hitSW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
					animator.SetTrigger("auto");
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						audioCom.clip = sounds[0];
						audioCom.Play();
						hitNW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
						animator.SetTrigger("auto");
					}
					if (!hitNW)
					{
						//if there was no attack then the ability is reset
						autoCanUse = true;
					}
				}
			}
		}
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
			audioCom.volume = mouseClick.mouseCLK.volume / 100;
			audioCom.clip = sounds[0];
			audioCom.Play();
			animator.SetTrigger("med");
			RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitNE)
			{
				hitNE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
			}
			if (!hitNE)
			{
				//send a raycast SE to see if there is a creep if there isnt on NE
				RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
				if (hitSE)
				{
					hitSE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
				}
				if (!hitSE)
				{
					//send a raycast SW to see if there is a creep if there isnt on SE
					RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
					if (hitSW)
					{
						hitSW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
					}
					if (!hitSW)
					{
						//send a raycast NW to see if there is a creep if there isnt on SW
						RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
						if (hitNW)
						{
							hitNW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
						}
					}
				}
			}
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
			audioCom.volume = mouseClick.mouseCLK.volume / 100;
			audioCom.clip = sounds[0];
			audioCom.Play();
			animator.SetTrigger("heavy");
			RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitNE)
			{
				hitNE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			}
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				hitSE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			}
			//send a raycast SW to see if there is a creep if there isnt on SE
			RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitSW)
			{
				hitSW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			}
			//send a raycast NW to see if there is a creep if there isnt on SW
			RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitNW)
			{
				hitNW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			}
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
			audioCom.volume = mouseClick.mouseCLK.volume / 100;
			audioCom.clip = sounds[1];
			audioCom.Play();
			AOEPanel.gameObject.SetActive(true);
			AOEPanel.localScale = new Vector3(1, 1, 1);
			AOEGameTime = Time.time;
			tempAOEData = Instantiate(AOEData, this.transform.position, Quaternion.identity) as GameObject;
			tempAOEData.GetComponent<AOEData>().stats(AOERange, AOEDamage);
		}
	}
}
