using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset = new Vector3();
	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCam = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCam, smoothing * Time.deltaTime);
		//transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, target.rotation,Time.deltaTime * smoothing);
	}
}
