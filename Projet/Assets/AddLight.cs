using UnityEngine;
using System.Collections;

public class AddLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject lightGameObject = new GameObject("PointLight");
		lightGameObject.AddComponent<Light>();
		lightGameObject.GetComponent<Light>().color = new Color (0.95f, 0.65f, 0.12f, 1);
		lightGameObject.GetComponent<Light>().cullingMask = LayerMask.GetMask("Sun");
		lightGameObject.GetComponent<Light>().range = 500;
		lightGameObject.GetComponent<Light>().type = LightType.Point;
		lightGameObject.transform.parent = GetComponent<Camera>().transform;
		lightGameObject.GetComponent<Light>().intensity = 3;
		lightGameObject.transform.localPosition = new Vector3 (0, 0, 0);

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
