using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	[SerializeField] Transform pos1;
	[SerializeField] Transform pos2;
	[SerializeField] Transform pos3;
	[SerializeField] Transform pos4;
	[SerializeField] Transform pos5;
	[SerializeField] Transform pos6;
	[SerializeField] Transform pos7;
	[SerializeField] Transform pos8;
	[SerializeField] Transform pos9;
	[SerializeField] GameObject Zombie;
	int randPos;
	Vector3 pos;

	// Start is called before the first frame update
	IEnumerator spawnZombie()
	{
		//if (!spawned)
		while (true)
		{
		//spawned = true;
			yield return new WaitForSeconds(20f);
			randPos = Random.Range(1, 9);
			if (randPos == 1)
			{
				pos = pos1.position;
			}
			else if (randPos == 2)
			{
				pos = pos2.position;
			}
			else if (randPos == 3)
			{
				pos = pos3.position;
			}
			else if (randPos == 4)
			{
				pos = pos4.position;
			}
			else if (randPos == 5)
			{
				pos = pos5.position;
			}
			else if (randPos == 6)
			{
				pos = pos6.position;
			}
			else if (randPos == 7)
			{
				pos = pos7.position;
			}
			else if (randPos == 8)
			{
				pos = pos8.position;
			}
			else if (randPos == 9)
			{
				pos = pos9.position;
			}
			Instantiate(Zombie, pos, Quaternion.identity);
		}
		//spawned = false;
	}
	IEnumerator Start()
    {
		//Time.fixedDeltaTime = 20;
		yield return StartCoroutine(spawnZombie());
    }

    // Update is called once per frame
    void Update()
    {
		
	}
	/*private void FixedUpdate()
	{
		StartCoroutine(spawnZombie());
	}*/
}
