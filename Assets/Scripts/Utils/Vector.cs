using UnityEngine;
using System.Collections;
namespace ActionRPGEngine.VectorUtils {
	public static class Vector {
		public static float sqrMagnitude(this Vector2 vec) {
			return vec.x * vec.x + vec.y * vec.y;
		}
	}
}
