using Core.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemy
{
	public class EnemyCollision : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out EnemyDeadZone zone))
				gameObject.SetActive(false);
			else if (col.TryGetComponent(out Player  player)) 
				SceneManager.LoadScene(0);
		}
	}
}