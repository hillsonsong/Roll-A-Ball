using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerContoller : MonoBehaviour {

	public float speed;//速度
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * 5);
	}

	void OnTriggerEnter(Collider other) {
//		Destroy (other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
			if(count >= 12) {
				winText.text = "You Win~!";
			}
		}
	}

	void SetCountText() {
		countText.text = "Count : " + count.ToString ();
	}
}