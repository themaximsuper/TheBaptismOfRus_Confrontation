using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;



public class InputUiManager : MonoBehaviour
{
	GameObject mp;
	[SerializeField] GameObject music;
	Playerstats playerstats;
	float x;
	float y;
	float z;
	bool cancel;
	bool cancel_cont;
	// Start is called before the first frame update
	void Start()
	{
		cancel= false;
		cancel_cont= false;
		playerstats = FindObjectOfType<Playerstats>();
		mp = GameObject.FindGameObjectWithTag("Player");
		if (PlayerPrefs.HasKey("PosX") && PlayerPrefs.HasKey("PosY") && PlayerPrefs.HasKey("PosZ"))
		{
			mp.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
		}
		if (PlayerPrefs.HasKey("Health"))
		{
			playerstats.health = PlayerPrefs.GetInt("Health");
		}
		//Debug.Log("x: " + PlayerPrefs.GetFloat("PosX").ToString() + " y: " + PlayerPrefs.GetFloat("PosY").ToString() + " z: " + PlayerPrefs.GetFloat("PosZ").ToString());
		//Debug.Log("x: " + mp.transform.position.x.ToString() + " y: " + mp.transform.position.y.ToString() + " z: " + mp.transform.position.z.ToString());
	}

    // Update is called once per frame
    void Update()
    {
	}
	private void LateUpdate()
	{
		mp = GameObject.FindGameObjectWithTag("Player");
		if (Input.GetButton("Cancel"))
		{
			
			//Debug.Log("x: " + mp.transform.position.x.ToString() + " y: " + mp.transform.position.y.ToString() + " z: " + mp.transform.position.z.ToString());
			x = mp.transform.position.x;
			y = mp.transform.position.y;
			z = mp.transform.position.z;
			PlayerPrefs.SetFloat("PosX",x);
			PlayerPrefs.SetFloat("PosY", y);
			PlayerPrefs.SetFloat("PosZ", z);
			PlayerPrefs.SetInt("Health", playerstats.health);
			cancel = true;
			//Debug.Log("x: " + PlayerPrefs.GetFloat("PosX").ToString() + " y: " + PlayerPrefs.GetFloat("PosY").ToString() + " z: " + PlayerPrefs.GetFloat("PosZ").ToString());
		}
		if (cancel)
		{
			if (x != PlayerPrefs.GetFloat("PosX"))
			{
				PlayerPrefs.SetFloat("PosX", x);
			}
			if (y != PlayerPrefs.GetFloat("PosY"))
			{
				PlayerPrefs.SetFloat("PosY", y);
			}
			if (z != PlayerPrefs.GetFloat("PosZ"))
			{
				PlayerPrefs.SetFloat("PosZ", z);
			}
			if (playerstats.health != PlayerPrefs.GetInt("Health"))
			{
				PlayerPrefs.SetInt("Health", playerstats.health);
			}
			if (x == PlayerPrefs.GetFloat("PosX") && y == PlayerPrefs.GetFloat("PosY") && z == PlayerPrefs.GetFloat("PosZ") && playerstats.health == PlayerPrefs.GetInt("Health"))
			{
				Debug.Log("Successful save.");
				cancel_cont= true;
				cancel = false;
			}
		}
		if (cancel_cont) {
			PlayerPrefs.Save();
			Main.music_volume = music.GetComponent<AudioSource>().volume;
			Music.playtime = music.GetComponent<AudioSource>().time;
			SceneManager.LoadScene(0);
			cancel_cont = false;
		}
	}
}