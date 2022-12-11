using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
	[SerializeField] Slider slider;
	[SerializeField] Text text;
	
    // Start is called before the first frame update
    void Start()
    {
		slider.value = Main.volume;
		text.text = Convert.ToInt64(Main.volume*100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
		AudioListener.volume = slider.value;
		Main.volume = AudioListener.volume;
		text.text = Convert.ToInt64(Main.volume * 100).ToString();
		PlayerPrefs.SetFloat("volume", Main.volume);
	}
}
