using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Covids : MonoBehaviour {

	public float		size = 1;
	public float		maxSpeed = 10;
	public float		maxRotSpeed = 5;
	public Rigidbody	rigid;

	float leftConstraint = Screen.width;
	float rightConstraint = Screen.width;
	float bottomConstraint = Screen.height;
	float topConstraint = Screen.height;
	float buffer = 1.0f;
	Camera cam;
	float distanceZ;

	Ray ray;
	RaycastHit hit;

	void Awake ()
	{
		rigid = GetComponent<Rigidbody> ();

		Init(size);

		cam = Camera.main;
		distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

		leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x + size / 2;
		rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x + size / 2;
		bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y + size / 2;
		topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y + size / 2;
	}

	public void Init(float inSize)
	{
		size = inSize;
		transform.localScale = Vector3.one * size;
		Vector3 vel = Random.onUnitSphere;
		vel.z = 0;
		vel.Normalize ();
		vel *= maxSpeed / size;

		rigid.velocity = vel;
		rigid.angularVelocity = Random.onUnitSphere * maxRotSpeed / size;
	}

	void FixedUpdate ()
	{
		if (transform.position.x < leftConstraint - buffer)
		{
			transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
		}
		if (transform.position.x > rightConstraint + buffer)
		{
			transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
		}
		if (transform.position.y < bottomConstraint - buffer)
		{
			transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
		}
		if (transform.position.y > topConstraint + buffer)
		{
			transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
		}
	}

    void OnMouseDown()
	{
		GameManager.S.Split(this);
	}
}
