using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform entityToFollow;
	public float speed;

	private new Transform transform;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}

	void Update()
	{
		if (entityToFollow != null)
		{
			float player_x = entityToFollow.position.x;
			float player_y = entityToFollow.position.y;

			Vector3 new_pos = new Vector3(player_x, player_y, -10.0f); // this is 2d, so my camera is that far from the screen.
			Camera.main.transform.position = Vector3.Lerp(transform.position, new_pos, speed);
		}
	}
}
