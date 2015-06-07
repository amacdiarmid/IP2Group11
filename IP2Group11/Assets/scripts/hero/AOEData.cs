using UnityEngine;
using System.Collections;

public class AOEData : MonoBehaviour {

	private int AOEDamage;
	private int pulseTime;
	private float gameTime;
	private bool canPulse;

	void Update()
	{
		if (canPulse == false)
		{
			if (Time.time - gameTime >= pulseTime)
			{
				canPulse = true;
			}
		}
	}

	public void stats(float tempRange, int tempDamage)
	{
		AOEDamage = tempDamage;
		this.GetComponent<CircleCollider2D>().radius = tempRange;
		canPulse = true;
		pulseTime = 1;
		gameTime = Time.time;
	}

	/// <summary>
	/// when the collider is active. every creep inside gets damage
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerStay2D(Collider2D other)
	{
		if (canPulse == true)
		{
			if (other.gameObject.tag == "Creep")
			{
				other.gameObject.GetComponent<creepMovement>().removeHealth(AOEDamage);
			}
			gameTime = Time.time;
			canPulse = false;
		}
	}
}
