using UnityEngine;
using System.Collections;

public class AsteroidGeneration : MonoBehaviour
{
	Mesh sourceMesh;
	Mesh workingMesh;
	MeshRenderer meshR;
	Transform tr;
	Vector3[] vertices;
	Vector3[] baseVertices;
	Vector3 rotationSpeed;
	float speed;
	float scale;
	Perlin noise;

	// Use this for initialization
	void Start()
	{
		/*MeshFilter meshfilter = gameObject.GetComponentInChildren<MeshFilter>();

		sourceMesh = new Mesh();
		// Get the sourceMesh from the originalSkinnedMesh
		sourceMesh = meshfilter.mesh;
		// Clone the sourceMesh 
		workingMesh = MeshUtils.CloneMesh(sourceMesh);
		// Reference workingMesh to see deformations
		meshfilter.sharedMesh = workingMesh;*/

		sourceMesh = GetComponent<MeshFilter>().mesh;
		tr = GetComponent<Transform>();
		//tr.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f));
		meshR = GetComponent<MeshRenderer>();
		baseVertices = sourceMesh.vertices;

		StartCoroutine("Generation");
		rotationSpeed = new Vector3(Random.Range(-0.12f, 0.12f), Random.Range(-0.12f, 0.12f), Random.Range(-0.12f, 0.12f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		tr.Rotate(rotationSpeed);
	}
	
	IEnumerator Generation()
	{
		int num = 0;
		speed = Random.Range(0.7f, 1.3f);
		scale = Random.Range(0.4f, 0.7f);
		noise = new Perlin();

		while(num < Random.Range(20,50))
		{
			var vertices = new Vector3[baseVertices.Length];

			float timex = Time.time * speed + 0.1365143f;
			float timey = Time.time * speed + 1.21688f;
			float timez = Time.time * speed + 2.5564f;

			for(int j = 0; j < vertices.Length; j++)
			{
					var vertex = baseVertices [j];

					vertex.x += noise.Noise (timex + vertex.x, timex + vertex.y, timex + vertex.z) * scale;
					vertex.y += noise.Noise (timey + vertex.x, timey + vertex.y, timey + vertex.z) * scale;
					vertex.z += noise.Noise (timez + vertex.x, timez + vertex.y, timez + vertex.z) * scale;

					vertices [j] = vertex;
			}

			sourceMesh.vertices = vertices;

			sourceMesh.RecalculateNormals();
			sourceMesh.RecalculateBounds();

			num++;
			yield return new WaitForSeconds (0.01f);
		}

		//sourceMesh.Optimize();
		//workingMesh.vertices = SmoothFilter.hcFilter(sourceMesh.vertices, workingMesh.vertices, workingMesh.triangles, 0.0f, 0.5f);

		Vector2 offset = new Vector2(256, 128);
		int rand = Random.Range(0,6);

		/*switch(rand)
		{
			case 0:
				offset = new Vector2(0, 0);
			break;
			case 1:
				offset = new Vector2(256, 0);
			break;
			case 2:
				offset = new Vector2(512, 0);
			break;
			case 3:
				offset = new Vector2(0, 128);
			break;
			case 4:
				offset = new Vector2(256, 128);
			break;
			case 5:
				offset = new Vector2(512, 128);
			break;
			case 6:
				offset = new Vector2(0, 256);
			break;
			case 7:
				offset = new Vector2(256, 256);
			break;
		}*/

		meshR.material = Resources.Load ("Material/asteroid" + rand) as Material ;
		//meshR.material.SetTexture(rand,SystemGenerator.sprites[rand]);
	}
}