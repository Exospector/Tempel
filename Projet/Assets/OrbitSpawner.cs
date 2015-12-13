using UnityEngine;
using System.Collections;

public class OrbitSpawner : MonoBehaviour
{
	public float orbitDegrees = 0.01f;
	public bool over;

	private Transform target;
	private float rotation = 0;

	// Use this for initialization
	void Start()
	{
		over = false;
		target = GameObject.FindGameObjectWithTag("Sun").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(target != null)
		{
			//rotation += orbitDegrees;
			if(rotation < 358)
			{
				transform.RotateAround(target.position, Vector3.up, orbitDegrees);
			}
		}
	}
}
