using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class heroAttack : MonoBehaviour {

	//the range of the hero
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

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		this.gameObject.GetComponent<CircleCollider2D>().radius = AOERange;
		this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

		autoCanUse = true;
		medCanUse = true;
		heavyCanUse = true;
		AOECanUse = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//med
		if (Input.GetKeyUp("ability1"))
		{
			if (medCanUse == true)
			{
				medCanUse = false;
				medAttack();
			}
		}
		//heavy
		else if (Input.GetKeyUp("ability2"))
		{
			if (heavyCanUse == true)
			{
				heavyCanUse = false;
				heavyAttack();
			}
		}
		//AOE
		else if (Input.GetKeyUp("ability3"))
		{
			if (AOECanUse == true)
			{
				AOECanUse = false;
				AOEAttack(1);
			}
		}
		else
		{
			if (autoCanUse == true)
			{
				autoCanUse = false;
				autoAttack();
			}
		}
	}

	void autoAttack()
	{
		//check for creep NE
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			Debug.Log("auto attack");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
			StartCoroutine(autoWait());
		}
		if (!hitNE)
		{
			//check for creep SE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				Debug.Log("auto attack");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
				StartCoroutine(autoWait());
			}
			if (!hitSE)
			{
				//check for creep SW
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					Debug.Log("auto attack");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
					StartCoroutine(autoWait());
				}
				if (!hitSE)
				{
					//check for creep NW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), autoAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						Debug.Log("auto attack");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(autoDamage);
						StartCoroutine(autoWait());
					}
					if (!hitNW)
					{
						Debug.Log("No auto attack");
					}
				}
			}
		}
	}
	void medAttack()
	{
		//check for creep NE
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), medAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			Debug.Log("med attack");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
			StartCoroutine(medWait());
		}
		if (!hitNE)
		{
			//check for creep SE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), medAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				Debug.Log("med attack");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(medDamage);
				StartCoroutine(medWait());
			}
			if (!hitSE)
			{
				//check for creep SW
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), medAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					Debug.Log("med attack");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
					StartCoroutine(medWait());
				}
				if (!hitSE)
				{
					//check for creep NW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), medAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						Debug.Log("med attack");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(medDamage);
						StartCoroutine(medWait());
					}
					if (!hitNW)
					{
						Debug.Log("No med attack");
					}
				}
			}
		}
	}
	void heavyAttack()
	{
		//check for creep NE
		RaycastHit2D hitNE = Physics2D.Raycast(this.transform.position, new Vector2(2, 1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
		if (hitNE)
		{
			Debug.Log("heavy attack");
			hitNE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
			StartCoroutine(heavyWait());
		}
		if (!hitNE)
		{
			//check for creep SE
			RaycastHit2D hitSE = Physics2D.Raycast(this.transform.position, new Vector2(2, -1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
			if (hitSE)
			{
				Debug.Log("heavy attack");
				hitSE.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
				StartCoroutine(heavyWait());
			}
			if (!hitSE)
			{
				//check for creep SW
				RaycastHit2D hitSW = Physics2D.Raycast(this.transform.position, new Vector2(-2, -1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
				if (hitSW)
				{
					Debug.Log("heavy attack");
					hitSW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
					StartCoroutine(heavyWait());
				}
				if (!hitSE)
				{
					//check for creep NW
					RaycastHit2D hitNW = Physics2D.Raycast(this.transform.position, new Vector2(-2, 1.2f), heavyAttackRange, LayerMask.GetMask("Creep"));
					if (hitNW)
					{
						Debug.Log("heavy attack");
						hitNW.collider.GetComponent<creepMovement>().removeHealth(heavyDamage);
						StartCoroutine(heavyWait());
					}
					if (!hitNW)
					{
						Debug.Log("No heavy attack");
					}
				}
			}
		}
	}
	//this may or may no work
	void AOEAttack(int i)
	{
		Debug.Log("AOE attack");
		if (i == 1)
		{
			this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		else
		{
			this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
			StartCoroutine(AOEWait());
		}	
	}

	void onTriggerStay(Collider2D other)
	{
		if (this.gameObject.GetComponent<CircleCollider2D>().enabled == true)
		{
			if (other.gameObject.tag == "Creep")
			{
				other.gameObject.GetComponent<creepMovement>().removeHealth(AOEDamage);
			}
		}
	}

	IEnumerator autoWait()
	{
		yield return new WaitForSeconds(autoCooldown);
		autoCanUse = true;
	}
	IEnumerator medWait()
	{
		yield return new WaitForSeconds(medCooldown);
		medCanUse = true;
	}
	IEnumerator heavyWait()
	{
		yield return new WaitForSeconds(heavyCooldown);
		heavyCanUse = true;
	}
	IEnumerator AOEWait()
	{
		yield return new WaitForSeconds(AOECooldown);
		AOECanUse = true;
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);
		AOEAttack(2);
	}

}
