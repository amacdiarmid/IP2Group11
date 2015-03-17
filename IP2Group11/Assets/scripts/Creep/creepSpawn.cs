using UnityEngine;
using System.Collections;

public class creepSpawn : MonoBehaviour {

	[HideInInspector] public float creepTimer;
	[HideInInspector] public int basicCreepNo;
	[HideInInspector] public GameObject basicCreep;
	[HideInInspector] public WaveData data;
	private bool spawnCreep = true;

	public void Update()
	{
		if (basicCreepNo > 0 && spawnCreep == true)
		{
			basicCreepNo--;
			Instantiate(basicCreep, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity);
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
