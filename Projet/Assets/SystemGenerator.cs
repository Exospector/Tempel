using UnityEngine;
using System.Collections;
using System.Linq;
public class SystemGenerator : MonoBehaviour
{
	public GameObject center;
	public float baseDensity = 4.5f;
	public float baseRotatingSpeed;

	private int nbBelts;
	private int[] usedDistances;
	private bool boolDistanceOK;

	private static int nbRoids;
	private static GUIText text;
	private GameObject GUIroids;
	private GameObject[] belts;
	private GameObject[] spawners;

	// Use this for initialization
	void Start()
	{
		int rand, j;
		int[] rands;

		GUIroids = GameObject.Find("Debug GUI/nbRoids");
		text = GUIroids.GetComponent(typeof(GUIText)) as GUIText;

		usedDistances = new int[2];

		// Génération d'une, deux, ou trois ceintures d'astéroides (60%, 30%, 10%)
		rand = Random.Range(0,10);
		if(rand == 0)
		{
			nbBelts = 3;
		}
		else if (rand > 0 && rand <=3)
		{
			nbBelts = 2;
		}
		else
		{
			nbBelts = 1;
		}
		nbBelts = 3;
		belts = new GameObject[nbBelts];
		spawners = new GameObject[nbBelts];
		rands = new int[nbBelts];

		for(int i = 0; i < nbBelts; i++)
		{
			rand = Random.Range(50, 150);
			rands[i] = rand;
			belts[i] = new GameObject("Belt" + (i + 1));
			OrbitAround orbit = belts[i].AddComponent<OrbitAround>() as OrbitAround;
			if(Random.Range(0,2) == 0)
				orbit.Init("belt", 0.002f, GameObject.FindGameObjectWithTag("Sun"));
			else
				orbit.Init("belt", -0.002f, GameObject.FindGameObjectWithTag("Sun"));

			do
			{
				boolDistanceOK = false;

				for(j = 0; j < nbBelts; j++)
				{
					if(j != i && rands[j] != 0)
					{
						if((rands[j] - rand < 30 && rands[j] - rand > 0)
						   || (rands[j] - rand > -30 && rands[j] - rand < 0))
						{
							boolDistanceOK = true;
						}
						else
						{
							rand = Random.Range(50, 150);
							rands[i] = rand;
							boolDistanceOK = false;
						}
					}
					else
					{
						boolDistanceOK = true;
					}
				}
			}while(!boolDistanceOK);

			spawners[i] = new GameObject();
			spawners[i].GetComponent<Transform>().position = new Vector3(rand, 0, 0);
			spawners[i].transform.parent = belts[i].transform;
			orbit = spawners[i].AddComponent<OrbitAround>() as OrbitAround;
			orbit.Init("spawner", 0.5f, GameObject.FindGameObjectWithTag("Sun"));
		
			StartCoroutine("spawnAsteroidsAround", i);
		}

		for(int h = 0; h < nbBelts; h++)
		{
			Debug.Log("rand " + h + " : " + rands[h]);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	private IEnumerator spawnAsteroidsAround(int i)
	{
		float density;
		density = baseDensity / spawners[i].transform.position.x + Random.Range(-0.01f, 0.01f);

		float[] asteroidSpacing = new float[2];
		asteroidSpacing[0] = Random.Range(-2.7f, 0.7f);
		asteroidSpacing[1] = Random.Range(0.7f, 2.7f);


		while(!spawners[i].gameObject.GetComponent<OrbitAround>().over)
		{
			GameObject asteroid;
			asteroid = GameObject.Instantiate(Resources.Load("Prefab/Asteroid")) as GameObject;
			asteroid.transform.parent = belts[i].transform;
			asteroid.transform.position = spawners[i].transform.position;
			asteroid.transform.position = new Vector3((asteroid.transform.position.x + Random.Range(asteroidSpacing[0], asteroidSpacing[1])),
			                                          (asteroid.transform.position.y + Random.Range(asteroidSpacing[0], asteroidSpacing[1])),
			                                          (asteroid.transform.position.z + Random.Range(asteroidSpacing[0], asteroidSpacing[1])));
			nbRoids++;
			text.text = "Roids : " + nbRoids;
			yield return new WaitForSeconds(density);
		}
	}
}
