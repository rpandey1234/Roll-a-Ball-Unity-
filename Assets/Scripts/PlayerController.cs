using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;

	// Use this for initialization (first frame)
	void Start () {
		rb = GetComponent<Rigidbody> ();	
		count = 0;
		setCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		rb.AddForce (new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed);

//		moveHorizontal = Input.GetAxis("Mouse X");
//		moveVertical = Input.GetAxis("Mouse Y");
		if (Input.touchCount > 0) {
			moveHorizontal = Input.touches[0].deltaPosition.x;
			moveVertical = Input.touches[0].deltaPosition.y;
		}
		rb.AddForce (new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
			if (count == 11) {
				winText.text = "YOU WIN!";	
			}
		}
	}

	void setCountText() {
		countText.text = "Count: " + count.ToString ();
	}
}
