using UnityEngine;
using System.Collections;

public class SunTextureMove : MonoBehaviour
{
	public float scrollSpeedX=0.015f;
	public float scrollSpeedY=0.015f;
	public float scrollXSpeedMaterial2=0.015f;
	public float scrollYSpeedMaterial2=0.015f;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		float offsetX = Time.time * scrollSpeedX % 1;
		float offsetY = Time.time * scrollSpeedY % 1;
		float offset2X = Time.time * scrollXSpeedMaterial2 % 1;
		float offset2Y = Time.time * scrollYSpeedMaterial2 % 1;
		GetComponent<Renderer>().materials[0].SetTextureOffset("_BumpMap",new Vector2(offsetX,offsetY));
		GetComponent<Renderer>().materials[0].SetTextureOffset("_MainTex",new Vector2(offsetX,offsetY));
		if (GetComponent<Renderer>().materials.Length > 1) {
			GetComponent<Renderer>().materials[1].SetTextureOffset("_MainTex",new Vector2(offset2X,offset2Y));
			GetComponent<Renderer>().materials[1].SetTextureOffset("_BumpMap",new Vector2(offset2X,offset2Y));
		}
		Vector3 rec = transform.parent.transform.localScale;
		if (rec.x / 5>1) {
			GetComponent<Renderer>().materials[0].SetTextureScale("_BumpMap",(new Vector2(rec.x/5,rec.x/5)));
			GetComponent<Renderer>().materials[0].SetTextureScale("_MainTex",(new Vector2(rec.x/5,rec.x/5)));
			GetComponent<Renderer>().materials[1].SetTextureScale("_BumpMap",(new Vector2(rec.x/5,rec.x/5)));
			GetComponent<Renderer>().materials[1].SetTextureScale("_MainTex",(new Vector2(rec.x/5,rec.x/5)));

		}
		}
}

