using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class heroAttack : MonoBehaviour {

	//the range of the hero
	public float Range;
	//the cooldown on each attack
	public float[] Cooldown = new float[4];
	//the damage for each attack
	public int[] Damage = new int[4];
	//the area for the AOE attack
	public float AreaOfEffect;
	//see if the AOE [0], medium[1] or heavy[2] are ready to use;
	private bool[] CanUse = new bool[4] {true, true, true, true};
	//the current creeps in the AOE range
	[HideInInspector] public List<creepMovement> creepCount;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<CircleCollider2D>().radius = AreaOfEffect;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CanUse[0] == true && creepCount.Count >= 5)
		{
			CanUse[0] = false;
			AOEAttack();
		}
	}

	void AOEAttack()
	{
		StartCoroutine(Wait(Cooldown[0], 0));
		foreach (var creep in creepCount)
		{
			Debug.Log("AOE attack");
			creep.HP = -Damage[0];
			if (creep.HP <= 0)
			{
				Destroy(creep.gameObject);
			}
		}	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Creep")
		{
			Debug.Log("creep added");
			creepCount.Add(other.GetComponent<creepMovement>());
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		creepCount.Remove(other.GetComponent<creepMovement>());
	}

	void OnTriggerStay2D(Collider2D creep)
	{
		if(creep.gameObject.tag=="Creep")
		{
			if (Vector2.Distance(this.gameObject.transform.position, creep.gameObject.transform.position) <= Range)
			{
				if (CanUse[1] == true)
				{
					Debug.Log("heavy attack");
					creep.GetComponent<creepMovement>().HP = -Damage[1];
					StartCoroutine(Wait(Cooldown[1], 1));
				}
				else if (CanUse[2] == true)
				{
					Debug.Log("medium attack");
					creep.GetComponent<creepMovement>().HP = -Damage[2];
					StartCoroutine(Wait(Cooldown[2], 2));
				}
				else if (CanUse[3] == true)
				{
					Debug.Log("light attack");
					creep.GetComponent<creepMovement>().HP = -Damage[3];
					StartCoroutine(Wait(Cooldown[3], 3));
				}
			}
			if (creep.GetComponent<creepMovement>().HP <= 0)
			{
				Destroy(creep.gameObject);
			}
		}
	}

	IEnumerator Wait(float time, int ability)
	{
		yield return new WaitForSeconds(time);
		CanUse[ability] = true;
	}
}
