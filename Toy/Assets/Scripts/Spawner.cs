using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public int numberOfEnemies = 20;
	public GameObject spawn;
	public Transform parent;


	void Awake ()
	{
		for (int i = 0; i < numberOfEnemies; ++i) 
		{
			GameObject go = Instantiate(spawn, GetRandomPosition (), Quaternion.identity) as GameObject;
			go.transform.parent = parent;
		}
	}

	Vector3 GetRandomPosition()
	{
		Vector3 randomPosition = new Vector3 (Random.Range (-30f, 30f), 0, Random.Range (-30f, 30f));
//		NavMeshHit hit;
//		NavMesh.SamplePosition (randomPosition, out hit, 100, NavMesh.GetAreaFromName("Default"));
//		randomPosition = hit.position;
		return randomPosition;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
