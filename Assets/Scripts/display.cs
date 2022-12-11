using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour
{
	[SerializeField] InputField width;
	[SerializeField] InputField height;
	[SerializeField] Text mode_text;
	FullScreenMode fullscrmode;
	int mode_index;
    // Start is called before the first frame update
    void Start()
    {
		width.text = Main.width.ToString();
		height.text = Main.height.ToString();
		if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
		{
			fullscrmode= FullScreenMode.ExclusiveFullScreen;
			mode_text.text = "Полноэкранный";
			mode_index = 0;
		} else if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow)
		{
			fullscrmode= FullScreenMode.FullScreenWindow;
			mode_text.text = "Оконный\nбезрамочный";
			mode_index = 1;
		} else if (Screen.fullScreenMode == FullScreenMode.Windowed)
		{
			fullscrmode= FullScreenMode.Windowed;
			mode_text.text = "Оконный";
			mode_index = 2;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Change()
	{
		if (mode_index == 0)
		{
			fullscrmode = FullScreenMode.FullScreenWindow;
			mode_index = 1;
			mode_text.text = "Оконный\nбезрамочный";

		} else if (mode_index == 1)
		{ 
			fullscrmode= FullScreenMode.Windowed;
			mode_index = 2;
			mode_text.text = "Оконный";
		} else if (mode_index == 2) 
		{
			fullscrmode = FullScreenMode.ExclusiveFullScreen;
			mode_index = 0;
			mode_text.text = "Полноэкранный";
		}
	}

	public void SaveScreen()
	{
		Screen.SetResolution(Convert.ToInt32(width.text), Convert.ToInt32(height.text), fullscrmode);

		PlayerPrefs.SetInt("width", Convert.ToInt32(width.text));
		PlayerPrefs.SetInt("height", Convert.ToInt32(height.text));
		PlayerPrefs.SetInt("fullscreenmode", mode_index);


		PlayerPrefs.Save();
	}
}
