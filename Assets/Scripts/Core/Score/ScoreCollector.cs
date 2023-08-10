using TMPro;
using UnityEngine;

namespace Core.Score
{
	public class ScoreCollector : MonoBehaviour
	{
		[SerializeField] private int _score;
		[SerializeField] private TextMeshProUGUI _scoreText;
		public int Score => _score;

		public void TakeBonus()
		{
			AddScore();
			UpdateUI();
		}

		private void AddScore() => _score++;
		private void UpdateUI() => _scoreText.text = $"SCORE: {_score}";
	}
}