using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
	
	public static int width;
	public static int height;
	public static int fullscreenmode;
	FullScreenMode fullscreen;
	public static float sensitivity;
	public static float volume = 1f;
	public static float music_volume = 1f;
	[SerializeField] GameObject music;
	
	void Start()
    {
		width = 1920;
		height = 1080;
		fullscreenmode = 0;
		if (PlayerPrefs.GetInt("width") == 0)
		{
			width = 1920;
			PlayerPrefs.SetInt("width", 1920);
		}
		if (PlayerPrefs.GetInt("height") == 0)
		{
			height = 1920;
			PlayerPrefs.SetInt("height", 1080);
		}
		width = PlayerPrefs.GetInt("width");
		height = PlayerPrefs.GetInt("height");
		fullscreenmode = PlayerPrefs.GetInt("fullscreenmode");

		if (fullscreenmode == 0)
		{
			fullscreen = FullScreenMode.ExclusiveFullScreen;
		} else if (fullscreenmode == 1)
		{
			fullscreen = FullScreenMode.FullScreenWindow;
		} else if (fullscreenmode == 2) 
		{
			fullscreen = FullScreenMode.Windowed;
		}
		Screen.SetResolution(width, height, fullscreen);


		if (PlayerPrefs.HasKey("volume") == false)
		{
			PlayerPrefs.SetFloat("volume", 1f);
		}
		if (PlayerPrefs.HasKey("music_volume") == false)
		{
			PlayerPrefs.SetFloat("music_volume", 1f);
		}
		volume = PlayerPrefs.GetFloat("volume");
		music_volume = PlayerPrefs.GetFloat("music_volume");
		AudioListener.volume = volume;
		music.GetComponent<AudioSource>().volume = music_volume;

		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

	}

    // Update is called once per frame
    void Update()
    {
    }
	public void quit()
	{
		PlayerPrefs.Save();
		Application.Quit();
	}
	public void titre()
	{
		//MusicData.toTitre = true;
		Music.playtime = music.GetComponent<AudioSource>().time;
		SceneManager.LoadScene(1);
	}
	public void settings()
	{
		Music.playtime = music.GetComponent<AudioSource>().time;
		SceneManager.LoadScene(2);
	}
	public void game()
	{
		Music.playtime = music.GetComponent<AudioSource>().time;
		SceneManager.LoadScene(3);
	}
}
