using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform entityToFollow;
	public float speed;
	public float tolerance;

	private new Transform transform;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 pos = entityToFollow.position;
		pos.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, pos, Time.deltaTime * speed);
		if (Vector3.Distance(transform.position, pos) < tolerance) {
			transform.position = pos;
		}
	}
}
