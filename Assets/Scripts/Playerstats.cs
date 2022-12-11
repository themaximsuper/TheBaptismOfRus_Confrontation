using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Playerstats : MonoBehaviour
{

	[Tooltip("Здоровье игрока")]
	[SerializeField] int starthealth = 100;
	[HideInInspector] public int health = 100;
	[Tooltip("Text HP")]
	[SerializeField] GameObject healthUIText;
	[Tooltip("Slider HP")]


	[SerializeField] GameObject healthUISlider;
	[SerializeField] GameObject music;
	[SerializeField] GameObject death_panel;
	[SerializeField] GameObject curseIcon1;
	[SerializeField] GameObject curseIcon2;
	[SerializeField] GameObject curseIcon3;

	public static bool death;
	Animator animator;
	Text _healthUIText;
	// Start is called before the first frame update
	void Start()
    {
		death = false;
		healthUISlider.SetActive(true);
		death_panel.SetActive(false);
		animator = GetComponent<Animator>();
		_healthUIText = healthUIText.GetComponent<Text>();
		health = starthealth;
		healthUISlider.GetComponent<Slider>().maxValue = starthealth;
    }
	IEnumerator wait(float seconds)
	{
		PlayerPrefs.DeleteKey("PosX");
		PlayerPrefs.DeleteKey("PosY");
		PlayerPrefs.DeleteKey("PosZ");
		PlayerPrefs.DeleteKey("Health");
		yield return new WaitForSeconds(seconds);
		Main.music_volume = music.GetComponent<AudioSource>().volume;
		Music.playtime = music.GetComponent<AudioSource>().time;
		death_panel.SetActive(false);
		SceneManager.LoadScene(0);

	}
	// Update is called once per frame
	void Update()
    {
		if (health < 0) health = 0;
		if (health > starthealth) health = starthealth;
		DrawHealthStats();
		if ((health < 0 || health == 0) && death == false)
		{
			death = true;
			dead();
		}
    }
	void DrawHealthStats ()
	{
		if (healthUIText != null)
		{
			_healthUIText.text = health.ToString();
		}
		if (healthUISlider.GetComponent<Slider>() != null)
		{
			healthUISlider.GetComponent<Slider>().value = health;
		}
	}

	public void dead()
	{
		animator.Play("death");
		animator.SetBool("running", false);
		healthUISlider.SetActive(false);
		curseIcon1.SetActive(false);
		curseIcon2.SetActive(false);
		curseIcon3.SetActive(false);
		death_panel.SetActive(true);
		StartCoroutine(wait(5.0f));
		
	}
}


