﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private int count;

	public UnityEngine.UI.Text text;
	public UnityEngine.UI.Text winText;


	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText();		}
	}

	void SetCountText()
	{
		text.text = "Count: " + count.ToString ();
		if (count == 6) {
			winText.text = "Win!";
		}
	}
}
