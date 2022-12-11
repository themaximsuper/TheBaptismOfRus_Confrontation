using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ToMain : MonoBehaviour
{
	VideoPlayer videoplayer;
	// Start is called before the first frame update
	void Start()
	{
		videoplayer = GetComponent<VideoPlayer>();
		if (videoplayer.canSetDirectAudioVolume)
			videoplayer.SetDirectAudioVolume(0, Main.volume);
		videoplayer.loopPointReached += OnVideoEnd;
	}


/*	private void OnDisable()
	{
		videoplayer.loopPointReached -= OnVideoEnd;
	}*/

	void OnVideoEnd(VideoPlayer vd)
	{
		SceneManager.LoadScene(0);
	}
	// Update is called once per frame
	void Update()
    {
        
    }
	
}
