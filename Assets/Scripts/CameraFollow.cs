using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	void LateUpdate () {
		Vector3 targetPosition = target.position;
		Vector3 pos = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		pos.z = -10;
		transform.position = pos;
	}
}
