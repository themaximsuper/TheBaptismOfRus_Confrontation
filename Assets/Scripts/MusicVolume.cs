using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] GameObject music;
	[SerializeField] Slider slider;
	[SerializeField] Text text;

	// Start is called before the first frame update
	void Start()
	{
		slider.value = Main.music_volume;
		text.text = Convert.ToInt64(Main.music_volume * 100).ToString();
	}

	// Update is called once per frame
	void Update()
	{
		music.GetComponent<AudioSource>().volume = slider.value;
		Main.music_volume = music.GetComponent<AudioSource>().volume;
		text.text = Convert.ToInt64(Main.music_volume * 100).ToString();
		PlayerPrefs.SetFloat("music_volume", Main.music_volume);
	}
}
