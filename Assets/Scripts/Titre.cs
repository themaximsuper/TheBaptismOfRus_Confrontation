using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Cancel"))
			SceneManager.LoadScene(0);

	}

	public void Main()
	{
		SceneManager.LoadScene(0);
	}
}
