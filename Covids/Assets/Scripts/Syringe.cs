using UnityEngine;
using System.Collections;

public class Syringe : MonoBehaviour {

	public float		speed = 10;
	public float		iX, iY;
	public Rigidbody	rigid;
	public float		bulletSpeed = 20;
	//public GameObject	bulletPrefab;

	//public float speed = 4f;
	//public Transform target;//this a child of the main gameobject with same transforms as boat default position this script does not effect it
	//public float damping = 2f;

	void Awake() {
		rigid = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		//Cursor.lockState = CursorLockMode.Confined;

		Vector3 mouseOnScreen = Input.mousePosition;
		mouseOnScreen.z = 10;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseOnScreen);
		iX = mousePos.x;
		iY = mousePos.y;
	}

	void FixedUpdate () {
		rigid.position = new Vector3(iX,iY+1,0);
	}
}
