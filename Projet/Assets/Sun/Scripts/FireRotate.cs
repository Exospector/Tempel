using UnityEngine;
using System.Collections;

public class FireRotate : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		Vector3 rec = transform.parent.parent.transform.localScale;
		if (name.Equals("Lueur")) {
			transform.Rotate (Vector3.up * Time.deltaTime * rec.x);
		} else {
			transform.Rotate (Vector3.up * Time.deltaTime * -rec.x);

		}
		}
}

