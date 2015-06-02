using UnityEngine;
using System.Collections;

public class AOEData : MonoBehaviour {

	private int AOEDamage;

	public void stats(float tempRange, int tempDamage)
	{
		AOEDamage = tempDamage;
		this.GetComponent<CircleCollider2D>().radius = tempRange;
	}

	/// <summary>
	/// when the collider is active. every creep inside gets damage
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("something inside range");
		//if the other is a creep
		if (other.gameObject.tag == "Creep")
		{
			//deal damage 
			Debug.Log("creep entered range");
			other.gameObject.GetComponent<creepMovement>().removeHealth(AOEDamage);
		}
	}
}
