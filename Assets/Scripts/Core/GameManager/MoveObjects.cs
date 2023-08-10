using UnityEngine;

namespace Core.GameManager
{
	public class MoveObjects : MonoBehaviour
	{
		[SerializeField] private GameObject _obstacles;
		[SerializeField] private GameObject _camera;
		[SerializeField] private Player.Player _player;

		private void LateUpdate()
		{
			Move(_obstacles.transform);
			Move(_camera.transform);
		}

		public void Move(Transform target)
		{
			if (target.transform.position.x < _player.transform.position.x)
				target.transform.position = Vector3.MoveTowards(target.transform.position, 
					new Vector3(_player.transform.position.x,  target.transform.position.y, 
						target.transform.position.z), 100f * Time.deltaTime);
		}
	}
}