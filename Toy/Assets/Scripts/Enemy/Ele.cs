using UnityEngine;
using System.Collections;

public class Ele : MonoBehaviour {


		NavMeshAgent nav;
		Animator anim;
		



		void Awake ()
		{
			nav = GetComponent <NavMeshAgent> ();
			anim = GetComponent <Animator> ();

		}

		Vector3 SetRandomPosition()
		{
			return new Vector3 (Random.Range (-100, 100), 0, Random.Range (-100, 100));
		}




		void Update ()
		{
			nav.SetDestination (SetRandomPosition());
		}
}
	
