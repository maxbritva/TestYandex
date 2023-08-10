using Core.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
	public class EnemyMove : MonoBehaviour
	{
		[SerializeField] private Vector3 _newUpPosition;
		[SerializeField] private Vector3 _newDownPosition;

		private Player _player;
		private float _speed;
		private bool _isUpDirection;

		[Inject]
		private void Construct(Player player) => _player = player;

		private void OnEnable()
		{
			_newUpPosition = GetPoints(1f,3f);
			_newDownPosition = GetPoints(-1f,-3f);
			_speed = GetRandomSpeed();
		}

		private void Update()
		{
			if (_isUpDirection)
				Move(_newUpPosition, false);
			else
				Move(_newDownPosition, true);
		}

		private void Move(Vector3 target, bool value)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
			if (transform.position == target)
				_isUpDirection = value;
		}

		private float GetRandomSpeed() => Random.Range(1.5f, 4f);
		private Vector3 GetPoints(float min, float max) => 
			new Vector3(_player.transform.position.x + 13f, Random.Range(min,max),0f);
	}
}