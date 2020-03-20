using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	static public 		GameManager S;
	public int			startingCovids = 8;
	public GameObject	covidPrefab;

	void Awake()
	{
		S = this;
	}

	// Use this for initialization
	void Start ()
	{
		Cursor.visible = false;

		// Instantiate some Covids
		for (int i = 0; i < startingCovids; i++) {
			GameObject go = Instantiate<GameObject> (covidPrefab);

			go.transform.position = Random.insideUnitSphere * 5;


		}
	}

	public void Split(Covids a0)
	{
		if(a0.size > 0.125)
		{
			float newSize = a0.size / 2;
			for(int i = 0; i < 2; i++)
			{
				GameObject cov = Instantiate<GameObject>(covidPrefab);
				Covids a1 = cov.GetComponent<Covids>();
				a1.Init(newSize);

				cov.transform.position = a0.transform.position;
			}
		}
		Destroy(a0.gameObject);
	}

}
