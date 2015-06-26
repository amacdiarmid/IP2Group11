﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class towerBehaviour : MonoBehaviour {

	public GameObject projectile;
	public List<float> RateOfFire;
	private bool canFire = true;
	public List<float> areaOfAttack;
	public List<int> damage;
	public List<int> speed;
	public List<int> cost;
	public List<int> Refund;
	public AudioClip[] sounds;
	[HideInInspector] public int towerLevel;
	public int maxTowerLevel;
	private AudioSource audioCom;

	// Use this for initialization
	void Start () {
		towerLevel = 0;
		this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)this.gameObject.transform.position.y + 20;
		this.gameObject.GetComponent<CircleCollider2D>().radius = areaOfAttack[towerLevel];
		audioCom = this.gameObject.GetComponent<AudioSource>();
		audioCom.volume = mouseClick.mouseCLK.volume / 100;
		audioCom.clip = sounds[0];
		audioCom.Play ();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag=="Creep")
		{
			if (canFire == true)
			{			
				GameObject shot = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
				audioCom.volume = mouseClick.mouseCLK.volume / 100;
				audioCom.clip = sounds[1];
				audioCom.Play();
				shot.GetComponent<projectileBehaviour>().target = other.transform;
				shot.GetComponent<projectileBehaviour>().damage = damage[towerLevel];
				shot.GetComponent<projectileBehaviour>().speed = speed[towerLevel];
				canFire = false;
				StartCoroutine("Wait");
			}		
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(RateOfFire[towerLevel]);
		canFire = true;
	}

	public void HideCollider()
	{
		if (this.gameObject.GetComponent<Collider2D>().enabled == false)
		{
			this.gameObject.GetComponent<Collider2D>().enabled = true;
		}
		else
		{
			this.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

	public void UpgradeTower()
	{
		//should use floats for precision
		//towerLevel++;
		this.gameObject.GetComponent<CircleCollider2D>().radius = areaOfAttack[towerLevel];
	}

}
