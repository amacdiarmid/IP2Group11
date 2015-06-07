using UnityEngine;
using System.Collections;

public class slashData : MonoBehaviour {

	private int damage;

	public void stats(int tempDamage)
	{
		damage = tempDamage;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "creep")
		{
			other.gameObject.GetComponent<creepMovement>().removeHealth(damage);
		}
	}
}
