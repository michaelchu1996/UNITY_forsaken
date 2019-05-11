using UnityEngine;
using System.Collections;

namespace TDGP.Demo
{
/// <summary>
/// Demo script. Updates players position based on input.
/// </summary>
	public class PlayerMovementHandler : MonoBehaviour
	{
        public static float test = GameHandler.health;
		public float MoveSpeed = 2.5f;

		void FixedUpdate ()
		{
			var move = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

			transform.Translate (move * MoveSpeed * Time.deltaTime, Space.World);
            test -= 0.1f;
            GameHandler.health = test;

		}

	}
}
