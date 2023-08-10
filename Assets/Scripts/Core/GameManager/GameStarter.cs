using TMPro;
using UnityEngine;

namespace Core.GameManager
{
	public class GameStarter : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D _playerRigidbody2D;
		[SerializeField] private TextMeshProUGUI _startText;


		public void StartGame()
		{
			_playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
			_startText.gameObject.SetActive(false);
		}
		
	}
}