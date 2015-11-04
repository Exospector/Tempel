using UnityEngine;
using System.Collections;

public class OrbitAround : MonoBehaviour {
	
	public bool over;

	public float orbitDegrees;
	public string type;
	public Transform target;
	public float rotation = 0;
	public bool ready;

	public void Init(string _type, float speed, GameObject around = null)
	{
		type = _type;
		orbitDegrees = speed;
		target = around.transform;
		ready = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if(ready)
		{
			switch(type)
			{
				case "spawner" :
					rotation += orbitDegrees;
					if(rotation < 358)
					{
						transform.RotateAround(target.position, Vector3.up, orbitDegrees);
					}
					else
					{
						over = true;
					}
				break;

				case "belt" :
					transform.RotateAround(target.position, Vector3.up, orbitDegrees);
				break;
			}

		}
	}
}
