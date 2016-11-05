using UnityEngine;
using System.Collections;

public class moveBall : MonoBehaviour {

	public Rigidbody rb;
	public int force;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){



		if(Input.GetKey (KeyCode.Space))
		{
			
			rb.useGravity = true;
			rb.AddForceAtPosition (new Vector3 (5.0f, 0, force), rb.position);
		}

	}
}
