using UnityEngine;
using System.Collections;

public class Smooth : MonoBehaviour
{
	Mesh sourceMesh;
	Mesh workingMesh;

	// Use this for initialization
	void Start ()
	{
		MeshFilter meshfilter = gameObject.GetComponentInChildren<MeshFilter>();

		sourceMesh = new Mesh();
		// Get the sourceMesh from the originalSkinnedMesh
		sourceMesh = meshfilter.mesh;
		// Clone the sourceMesh 
		workingMesh = MeshUtils.CloneMesh(sourceMesh);
		// Reference workingMesh to see deformations
		meshfilter.mesh = workingMesh;

		workingMesh.vertices = SmoothFilter.hcFilter(sourceMesh.vertices, workingMesh.vertices, workingMesh.triangles, 0.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
