using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Head : MonoBehaviour
{
	[Range(0, 10)][SerializeField] float sensitive = 5.0f;
	public float headSensetive;
	
	[SerializeField] Vector2 clampAngle = new Vector2(-45.0f, 45.0f);

	Vector2 angle;
	float mouseX;
	float mouseY;
	// Start is called before the first frame update
	void Start()
    {
		headSensetive = sensitive;
	}

    // Update is called once per frame
    void Update()
	{

	}
	private void LateUpdate()
	{
		mouseY = Input.GetAxis("Mouse Y");
		mouseX = Input.GetAxis("Mouse X");

		angle.x -= mouseY * sensitive;
		angle.y += mouseX * sensitive;
		angle.x = Mathf.Clamp(angle.x, clampAngle.x, clampAngle.y);
		Quaternion rot = Quaternion.Euler(angle.x, angle.y, 0);
		transform.rotation = rot;
	}
}
