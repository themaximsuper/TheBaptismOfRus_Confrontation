using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurseSphere : MonoBehaviour
{
	[Header("Настройки")]

	[SerializeField] float curseLevelHigh = 20.0f;
	Color colorCurseHigh = Color.red;

	[SerializeField] float curseLevelLow = 10.0f;
	Color colorCurseLow = Color.green;

	[SerializeField] GameObject clip;
	[SerializeField] GameObject icon;

	Transform player;
	Playerstats playerStats;

	[SerializeField] int damageLow = 1;
	[SerializeField] int damageHigh = 3;

	[SerializeField] float timeToDamage = 1.0f;

	int damage;
	float timer;

	void Start()
    {
		icon.SetActive(false);
		colorCurseHigh.a = 1.0f;
		colorCurseLow.a = 1.0f;
		clip.SetActive(false);
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerStats = FindObjectOfType<Playerstats>();
    }

    // Update is called once per frame
    void Update()
    {
		if (player != null)
		{
			if (Time.time > timer + timeToDamage)
			{
				playerStats.health -= damage;
				timer = Time.time;
			}
		}
    }
	private void LateUpdate()
	{
		if (player != null)
		{
			if (Vector3.Distance(transform.position, player.position) < curseLevelHigh)
			{
				icon.SetActive(true);
				clip.SetActive(true);
				damage = damageHigh;
			}

			if (Vector3.Distance(transform.position, player.position) < curseLevelLow &&
				Vector3.Distance(transform.position, player.position) > curseLevelHigh)
			{
				icon.SetActive(true);
				clip.SetActive(true);
				damage = damageLow;
			}
			if (Vector3.Distance(transform.position, player.position) > curseLevelLow)
			{
				icon.SetActive(false);
				clip.SetActive(false);
				damage = 0;
			}
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = colorCurseHigh;
		Gizmos.DrawWireSphere(transform.position, curseLevelHigh);


		Gizmos.color = colorCurseLow;
		Gizmos.DrawWireSphere(transform.position, curseLevelLow);
	}
}
