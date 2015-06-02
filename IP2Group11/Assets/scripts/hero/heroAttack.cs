using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum countdown
{
	auto,
	medium,
	heavy,
	AOE,
};

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
				if (medCanUse == true)
				{
					medCanUse = false;
					medAttack();
					GetComponent<AudioSource>().clip = sounds[0];
					GetComponent<AudioSource>().Play();
				}
			}
			//the Heavy attack button has been called
			else if (Input.GetButtonUp("Heavy Attack"))
			{
				if (heavyCanUse == true)
				{
					heavyCanUse = false;
					heavyAttack();
					GetComponent<AudioSource>().clip = sounds[0];
					GetComponent<AudioSource>().Play();
				}
			}
			//the AOE attack button has been called
			else if (Input.GetButtonUp("AOE Attack"))
			{
				if (AOECanUse == true)
				{
					AOECanUse = false;
					AOEAttack();
					GetComponent<AudioSource>().clip = sounds[1];
					GetComponent<AudioSource>().Play ();
				}
			}
			else
			{
				//the no attack has been called so the auto attack can be called if it is ready
				if (autoCanUse == true)
				{
					autoCanUse = false;
					//autoAttack();
				}
			}
		}		
	}

	/// <summary>
	/// this is called if the auto attack has been slected in the update
	/// </summary>
	void autoAttack()
	{
		//Debug.Log("start auto attack");
		//send a raycast NE to see if there is a creep
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			//if there is then there is an attack
			Debug.Log("auto attack");
			animator.SetTrigger("auto");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
			StartCoroutine("cooldown", countdown.auto);
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				//if there is then there is an attack
				Debug.Log("auto attack");
				animator.SetTrigger("auto");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
				StartCoroutine("cooldown", countdown.auto);
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					//if there is then there is an attack
					Debug.Log("auto attack");
					animator.SetTrigger("auto");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
					StartCoroutine("cooldown", countdown.auto);
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						//if there is then there is an attack
						Debug.Log("auto attack");
						animator.SetTrigger("auto");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
						StartCoroutine("cooldown", countdown.auto);
					}
					if (!hitNW)
					{
						//if there was no attack then the ability is reset
						//Debug.Log("No auto attack");
						autoCanUse = true;
					}
				}
			}
		}
	}

	/// <summary>
	/// this is called if the medium attack has been slected in the update
	/// </summary>
	void medAttack()
	{
		//send a raycast NE to see if there is a creep
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), medAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			//if there is then there is an attack
			Debug.Log("med attack");
			animator.SetTrigger("med");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
			StartCoroutine("cooldown", countdown.medium);
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), medAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				//if there is then there is an attack
				Debug.Log("med attack");
				animator.SetTrigger("med");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
				StartCoroutine("cooldown", countdown.medium);
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), medAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					//if there is then there is an attack
					Debug.Log("med attack");
					animator.SetTrigger("med");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
					StartCoroutine("cooldown", countdown.medium);
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), medAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						//if there is then there is an attack
						Debug.Log("med attack");
						animator.SetTrigger("med");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
						StartCoroutine("cooldown", countdown.medium);
					}
					if (!hitNW)
					{
						//if there was no attack then the ability is reset
						Debug.Log("No med attack");
						medCanUse = true;
					}
				}
			}
		}
	}
	/// <summary>
	/// this is called if the heavy attack has been slected in the update
	/// </summary>
	/// 
	void heavyAttack()
	{
		//send a raycast NE to see if there is a creep
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			//if there is then there is an attack
			Debug.Log("heavy attack");
			animator.SetTrigger("heavy");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			StartCoroutine("cooldown", countdown.heavy);
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				//if there is then there is an attack
				Debug.Log("heavy attack");
				animator.SetTrigger("heavy");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
				StartCoroutine("cooldown", countdown.heavy);
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					//if there is then there is an attack
					Debug.Log("heavy attack");
					animator.SetTrigger("heavy");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
					StartCoroutine("cooldown", countdown.heavy);
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						//if there is then there is an attack
						Debug.Log("heavy attack");
						animator.SetTrigger("heavy");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
						StartCoroutine("cooldown", countdown.heavy);
					}
					if (!hitNW)
					{
						//if there was no attack then the ability is reset
						Debug.Log("No heavy attack");
						heavyCanUse = true;
					}
				}
			}
		}
	}
	/// <summary>
	/// this is called if the AOE attack has been slected in the update
	/// the paramiter is used to determine if this is the first or second call to this method
	/// </summary>
	void AOEAttack()
	{
		Debug.Log("AOE attack");
		tempAOEData = Instantiate(AOEData, this.transform.position, Quaternion.identity) as GameObject;
		tempAOEData.GetComponent<AOEData>().stats(AOERange, AOEDamage);
		StartCoroutine("cooldown", countdown.AOE);
	}

	/// <summary>
	/// cooldown for the auto attack
	/// called after the attack
	/// </summary>
	/// <returns></returns>
	IEnumerator cooldown(countdown coutdwn)
	{
		if (coutdwn == countdown.auto)
		{
			yield return new WaitForSeconds(autoCooldown);
			autoCanUse = true;
		}
		else if (coutdwn == countdown.medium)
		{
			yield return new WaitForSeconds(medCooldown);
			medCanUse = true;
		}
		else if (coutdwn == countdown.heavy)
		{
			yield return new WaitForSeconds(heavyCooldown);
			heavyCanUse = true;
		}
		else if (coutdwn == countdown.AOE)
		{
			yield return new WaitForSeconds(AOELength);
			Destroy(tempAOEData);
			yield return new WaitForSeconds(AOECooldown);
			AOECanUse = true;
		}
	}
}
