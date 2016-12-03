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

	void Update()
	{
		if (entityToFollow != null)
		{
			float player_x = entityToFollow.position.x;
			float player_y = entityToFollow.position.y;

			float rounded_x = RoundToNearestPixel(player_x);
			float rounded_y = RoundToNearestPixel(player_y);

			Vector3 new_pos = new Vector3(rounded_x, rounded_y, -10.0f); // this is 2d, so my camera is that far from the screen.
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new_pos, 0.16f);
		}
	}
	public float pixelToUnits = 128f;

	public float RoundToNearestPixel(float unityUnits)
	{
		float valueInPixels = unityUnits * pixelToUnits;
		valueInPixels = Mathf.Round(valueInPixels);
		float roundedUnityUnits = valueInPixels * (1 / pixelToUnits);
		return roundedUnityUnits;
	}


}
