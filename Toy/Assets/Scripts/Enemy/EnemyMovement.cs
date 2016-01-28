using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;
	public Light light;
	Animator anim;

	Color happyColor = Color.blue;
	Color angryColor = Color.red;
	float happySpeed = 1;
	float angrySpeed = 5;
	Vector3 randomPosition;
	static int happy = Animator.StringToHash("MoveHappy");
	GameObject ele;



    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		happy = Animator.StringToHash("MoveHappy");
		SetAngry ();

    }

	void Start()
	{
		SetRandomPosition ();
	}

	void SetRandomPosition()
	{
		GameObject[] eles = GameObject.FindGameObjectsWithTag ("ele");
		ele = eles[Random.Range(0, eles.Length-1)];
		
//		NavMeshHit hit;
//		NavMesh.SamplePosition (randomPosition, out hit, 10000000, NavMesh.GetAreaFromName("Default"));
//		randomPosition = hit.position;
		//print (randomPosition);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag != "Player") {
			SetRandomPosition ();
		} 
	}

	void SetAngry()
	{
		light.color = angryColor;
		anim.SetTrigger ("Angry");
		nav.speed = angrySpeed;
	}

	void SetHappy()
	{
		light.color = happyColor;
		anim.SetTrigger ("Happy");
		nav.speed = happySpeed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "gun") 
		{
			SetHappy ();
		} else  if ( other.gameObject.tag == "ele" ){
			SetAngry ();
		}
	}


    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
		if (happy == anim.GetCurrentAnimatorStateInfo (0).shortNameHash) 
		{
//			if (nav.remainingDistance <= nav.stoppingDistance) {
//				SetRandomPosition ();
//			}
			nav.SetDestination (ele.transform.position);
		} else {
			nav.SetDestination (player.position);
		}


        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
