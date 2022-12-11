using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	public static float playtime = 0.0f;
	AudioSource music;
	[SerializeField] GameObject audio_src;
    // Start is called before the first frame update
    void Start()
    {
		
		music = audio_src.GetComponent<AudioSource>();
		music.time = playtime;

		audio_src.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
