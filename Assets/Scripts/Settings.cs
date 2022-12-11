using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
	[SerializeField] GameObject music;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Cancel"))
		{
			back();
		}
    }
	public void back()
	{
		Music.playtime = music.GetComponent<AudioSource>().time;
		SceneManager.LoadScene(0);
	}

	public void Restore()
	{
		PlayerPrefs.DeleteAll();
	}
}
