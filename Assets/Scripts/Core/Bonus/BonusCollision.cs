using System.Collections;
using Core.Score;
using Enemy;
using UnityEngine;
using Zenject;

namespace Core.Bonus
{
	public class BonusCollision : MonoBehaviour
	{
		private ScoreCollector _scoreCollector;
		private Player.Player _player;
		
		[Inject] private void Construct(Player.Player player, ScoreCollector scoreCollector)
		{
			_scoreCollector = scoreCollector;
			_player = player;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out Player.Player player)) 
				StartCoroutine(MoveToPlayer());
			if (col.TryGetComponent(out EnemyDeadZone zone)) 
				HideBonus();
		}

		private void HideBonus() => gameObject.SetActive(false);
		private void TakeBonus() => _scoreCollector.TakeBonus();

		private IEnumerator MoveToPlayer()
		{
			while (true)
			{
				transform.position =
					Vector3.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * 15f);
				if (Vector2.Distance(transform.position, _player.transform.position) <= 0.1f)
				{
					TakeBonus();
					HideBonus();
					break;
				}
				yield return null;
			}
		}
	}
}