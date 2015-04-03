using UnityEngine;
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
	public AudioClip[] sounds;

	// Use this for initialization
	void Start () {
		//show the AOE collider, set the size of the radius, then hide it
		this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		this.gameObject.GetComponent<CircleCollider2D>().radius = AOERange;
		this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
		//set all the abilities to true so they can be used
		autoCanUse = true;
		medCanUse = true;
		heavyCanUse = true;
		AOECanUse = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//the medium attack button has been called
		if (Input.GetButtonUp("ability1"))
		{
			if (medCanUse == true)
			{
				medCanUse = false;
				medAttack();
			}
		}
		//the Heavy attack button has been called
		else if (Input.GetButtonUp("ability2"))
		{
			if (heavyCanUse == true)
			{
				heavyCanUse = false;
				heavyAttack();
				audio.clip = sounds[0];
				audio.Play ();
			}
		}
		//the AOE attack button has been called
		else if (Input.GetButtonUp("ability3"))
		{
			if (AOECanUse == true)
			{
				AOECanUse = false;
				AOEAttack(1);
				audio.clip = sounds[1];
				audio.Play ();
			}
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
	/// <summary>
	/// this is called if the auto attack has been slected in the update
	/// </summary>
	void autoAttack()
	{
		Debug.Log("start auto attack");
		//send a raycast NE to see if there is a creep
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			//if there is then there is an attack
			Debug.Log("auto attack");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
			StartCoroutine(autoWait());
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				//if there is then there is an attack
				Debug.Log("auto attack");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
				StartCoroutine(autoWait());
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					//if there is then there is an attack
					Debug.Log("auto attack");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
					StartCoroutine(autoWait());
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						//if there is then there is an attack
						Debug.Log("auto attack");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
						StartCoroutine(autoWait());
					}
					if (!hitNW)
					{
						//if there was no attack then the ability is reset
						Debug.Log("No auto attack");
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
			hitNE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
			StartCoroutine(medWait());
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), medAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				//if there is then there is an attack
				Debug.Log("med attack");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
				StartCoroutine(medWait());
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), medAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					//if there is then there is an attack
					Debug.Log("med attack");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
					StartCoroutine(medWait());
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), medAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						//if there is then there is an attack
						Debug.Log("med attack");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
						StartCoroutine(medWait());
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
	void heavyAttack()
	{
		//send a raycast NE to see if there is a creep
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			//if there is then there is an attack
			Debug.Log("heavy attack");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			StartCoroutine(heavyWait());
		}
		if (!hitNE)
		{
			//send a raycast SE to see if there is a creep if there isnt on NE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				//if there is then there is an attack
				Debug.Log("heavy attack");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
				StartCoroutine(heavyWait());
			}
			if (!hitSE)
			{
				//send a raycast SW to see if there is a creep if there isnt on SE
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					//if there is then there is an attack
					Debug.Log("heavy attack");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
					StartCoroutine(heavyWait());
				}
				if (!hitSW)
				{
					//send a raycast NW to see if there is a creep if there isnt on SW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						//if there is then there is an attack
						Debug.Log("heavy attack");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
						StartCoroutine(heavyWait());
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
	/// <param name="i"></param>
	void AOEAttack(int i)
	{
		Debug.Log("AOE attack");
		if (i == 1)
		{
			//if this is the first call then activate the AOE collider
			this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		else
		{
			//if this is no the first call then hide the AOE collider
			this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
			StartCoroutine(AOEWait());
		}	
	}
	/// <summary>
	/// when the collider is active. every creep inside gets damage
	/// </summary>
	/// <param name="other"></param>
	void onTriggerStay(Collider2D other)
	{
		//if the collider is active
		if (this.gameObject.GetComponent<CircleCollider2D>().enabled == true)
		{
			//if the other is a creep
			if (other.gameObject.tag == "Creep")
			{
				//deal damage 
				other.gameObject.GetComponent<creepMovement>().removeHealth(AOEDamage);
			}
		}
	}
	/// <summary>
	/// cooldown for the auto attack
	/// called after the attack
	/// </summary>
	/// <returns></returns>
	IEnumerator autoWait()
	{
		Debug.Log("co routine test start");
		yield return new WaitForSeconds(autoCooldown);
		autoCanUse = true;
		Debug.Log("co routine test end");
	}
	/// <summary>
	/// cooldown for the medium attack
	/// called after the attack
	/// </summary>
	/// <returns></returns>
	IEnumerator medWait()
	{
		yield return new WaitForSeconds(medCooldown);
		medCanUse = true;
	}
	/// <summary>
	/// cooldown for the heavy attack
	/// called after the attack
	/// </summary>
	/// <returns></returns>
	IEnumerator heavyWait()
	{
		yield return new WaitForSeconds(heavyCooldown);
		heavyCanUse = true;
	}
	/// <summary>
	/// cooldown for the AOE attack
	/// called after the attack
	/// </summary>
	/// <returns></returns>
	IEnumerator AOEWait()
	{
		yield return new WaitForSeconds(AOECooldown);
		AOECanUse = true;
	}
	/// <summary>
	/// this is called after the AOE collider is active 
	/// it will keep the collider active for 1 second
	/// before calling the AOE attack again to hide the collider
	/// </summary>
	/// <returns></returns>
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);
		AOEAttack(2);
	}

}
