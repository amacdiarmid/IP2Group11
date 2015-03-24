using UnityEngine;
using System.Collections;

public class creepSpawn : MonoBehaviour {

	[HideInInspector] public float creepTimer;

	[HideInInspector] public GameObject basicCreep;
	[HideInInspector] public int BasicCreepCount;
	[HideInInspector] public GameObject CancerCreep;
	[HideInInspector] public int CancerCreepCount;

	[HideInInspector] public waveData data;
	private bool spawnCreep = true;

	public void Update()
	{
		if (BasicCreepCount > 0 && spawnCreep == true)
		{
			BasicCreepCount--;
			Instantiate(basicCreep, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity);
			data.spawnedCreeps++;
			StartCoroutine("Wait");
		}
		if (CancerCreepCount > 0 && spawnCreep == true)
		{
			CancerCreepCount--;
			Instantiate(CancerCreep, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity);
			data.spawnedCreeps++;
			StartCoroutine("Wait");
		}
	}

	public void NextCreep()
	{
		spawnCreep = true;
	}

	IEnumerator Wait()
	{
		spawnCreep = false;
		yield return new WaitForSeconds(creepTimer);
		spawnCreep = true;
		NextCreep();
	}
}
