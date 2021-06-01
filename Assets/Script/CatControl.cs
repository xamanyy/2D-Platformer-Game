using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControl : MonoBehaviour {

	float dirX;
	[SerializeField]
	float moveSpeed;
	Rigidbody2D rb;
	AudioSource audioSrc;
	bool isMoving = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		audioSrc = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.GetAxis ("Horizontal") * moveSpeed;

		if (rb.velocity.x >= 1 || rb.velocity.x <= -1)
			isMoving = true;
		else
			isMoving = false;

		if (isMoving) {
			if (!audioSrc.isPlaying)
			audioSrc.Play ();
		}
		else
			audioSrc.Stop ();
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (dirX, rb.velocity.y);
	}
}
