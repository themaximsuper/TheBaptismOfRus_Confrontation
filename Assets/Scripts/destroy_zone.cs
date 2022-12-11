using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_zone : MonoBehaviour
{
	
	[SerializeField] GameObject zone;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
		{
			Destroy(zone);
		}

	}
}
