using UnityEngine;
using UnityEngine.Events;

namespace Core.Player
{
	public enum GameState
	{
		Prepare,
		Started
	}
	public class Input : MonoBehaviour
	{
		[SerializeField] private UnityEvent _startGame;
		[SerializeField] private global::Core.Player.Player _player;
		private GameState _gameState;

		private void Awake() => _gameState = GameState.Prepare;

		private void Update()
		{
			if (UnityEngine.Input.GetMouseButton(0))
			{
				if (_gameState == GameState.Prepare)
				{
					_startGame?.Invoke();
					_gameState = GameState.Started;
				}
				_player.Jump();
			}
		}
	}
}