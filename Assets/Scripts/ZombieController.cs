using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
	[SerializeField] float viewRadius = 50f;
	[SerializeField] float attackRadius = 7f;
	[SerializeField] int damage = 10;
	public int health = 50;
	[SerializeField] NavMeshAgent agent;
	Playerstats playerstats;
	Animator animator;
	bool attack;
	bool takenDamage;
	CapsuleCollider colliderr;
	bool giveHP;
	GameObject player;
	// Start is called before the first frame update

	IEnumerator Attackk()
	{
		
		yield return new WaitForSeconds(2.19f);
		if (Vector3.Distance(transform.position, player.transform.position) <= attackRadius)
		{
			playerstats.health -= damage;
		}
		animator.SetBool("attack", false);
		attack= false;
	}
	IEnumerator Death()
	{
		animator.Play("death");
		yield return new WaitForSeconds(2.29f);
		Destroy(gameObject);
	}
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		colliderr = GetComponent<CapsuleCollider>();
		playerstats = player.GetComponent<Playerstats>();
		animator= GetComponent<Animator>();
		animator.SetBool("attack", false);
		animator.SetBool("running", false);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void LateUpdate()
	{
		if (health > 0)
		{
			if (Playerstats.death != true)
			{
				if (Vector3.Distance(transform.position, player.transform.position) > attackRadius)
				{
					if (Vector3.Distance(transform.position, player.transform.position) <= viewRadius)
					{
						transform.LookAt(player.transform.position);
						agent.isStopped = false;
						animator.SetBool("attack", false);
						animator.SetBool("running", true);
						agent.SetDestination(player.transform.position);
					}
					else if (Vector3.Distance(transform.position, player.transform.position) > viewRadius)
					{
						agent.isStopped = true;
						animator.SetBool("attack", false);
						animator.SetBool("running", false);
					}
				}
				else if (Vector3.Distance(transform.position, player.transform.position) <= attackRadius && attack == false)
				{
					transform.LookAt(player.transform.position);
					attack = true;
					agent.isStopped = true;
					animator.SetBool("running", false);
					animator.SetBool("attack", true);
					StartCoroutine(Attackk());
				}
				if (Vector3.Distance(transform.position, player.transform.position) <= 6.0f && Player_Movement._attack == true && takenDamage == false)
				{
					takenDamage= true;
					health -= 10;
					Debug.Log(health);
				}
				if (Player_Movement._attack == false) 
				{
					takenDamage = false;
				}
			}
		} else
		{
			colliderr.enabled = false;
			agent.isStopped = true;
			animator.SetBool("attack", false);
			animator.SetBool("running", false);
			animator.Play("death");
			if (giveHP == false)
			{
				giveHP = true;
				playerstats.health += Random.Range(0, 10);
			}
				
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, viewRadius);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRadius);
	}
}