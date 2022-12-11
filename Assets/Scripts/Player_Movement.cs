using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
	public float attackRadius = 6f;
	[Range(0,1000)][SerializeField] float speedMove = 50.0f;
	[Range(0,1000)][SerializeField] float jump = 70.0f;
	[Range(0,1000)][SerializeField] float airGravity = 100.0f;
	[Range(0,1000)][SerializeField] float groundGravity = 500.0f;
	[SerializeField] AudioClip walking;
	[SerializeField] AudioClip jumping;
	Animator animator;
	CharacterController characterController;
	Head head;
	AudioSource audio_src;

	Vector3 _direction;
	float _vertical;
	float _horizontal;
	float _gravity;
	public static bool _attack = false;

	

	IEnumerator wait(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}
    void Start()
    {
		audio_src = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		characterController = GetComponent<CharacterController>();
		head = GetComponentInChildren<Head>();
		
    }
    void Update()
    {
		
		if (characterController.isGrounded)
		{
			if (_attack == false && Playerstats.death == false)
			{
				_vertical = Input.GetAxis("Vertical");
				_horizontal = Input.GetAxis("Horizontal");
				if ((_vertical != 0f || _horizontal != 0f) && audio_src.isPlaying == false)
				{
					audio_src.clip = walking;
					audio_src.Play();
				}
				else if (_vertical == 0f && _horizontal == 0f)
				{
					audio_src.Stop();
				}
				animator.SetBool("running", (_vertical != 0.0f || _horizontal != 0.0f));
				_gravity = groundGravity;
				_direction = transform.TransformDirection(_horizontal, 0.0f, _vertical);
				_direction *= speedMove;
				if (Input.GetButton("Jump"))
				{
					audio_src.clip = jumping;
					audio_src.Play();
					animator.Play("jump");
					_direction.y = jump;
				}
			}
			if (Input.GetButton("Fire1") && _attack == false)
			{
				_attack = true;
				animator.Play("attack");
			}
			if (_attack == true)
			{
				_vertical = 0.0f;
				_horizontal = 0.0f;
				_direction = Vector3.zero;
			}
		}
		else
		{
			_gravity = airGravity;
		}

		_direction.y -= _gravity * Time.deltaTime;
		characterController.Move(_direction * Time.deltaTime);
    }

	private void LateUpdate()
	{
		Quaternion b = new Quaternion(0, head.transform.rotation.y, 0, head.transform.rotation.w);
		transform.rotation = Quaternion.Lerp(transform.rotation, b, Time.deltaTime * head.headSensetive);


	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, attackRadius);
	}

}
