using UnityEngine;

namespace Core.Player
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D _rigidbody2D;
		[SerializeField] private float _forcePower = 1f;
	
		public void Jump() => _rigidbody2D.AddForce(new Vector2(0.6f,1f) * (_forcePower * Time.deltaTime), ForceMode2D.Impulse);
	}
}