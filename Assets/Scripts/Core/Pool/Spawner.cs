using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Pool
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Transform _spawnPoint;
		[SerializeField] private GameObjectPool _gameObjectPool;
		[SerializeField] private bool _isEnemy;
		
		private WaitForSeconds _interval;
		private void Start() => _interval = new WaitForSeconds(2.5f);
		public void StartSpawn() => StartCoroutine(SpawnSetInterval());

		private IEnumerator SpawnSetInterval()
		{
			while (true)
			{
				GameObject objectFromPool = _gameObjectPool.GetObjectFromPool(_isEnemy);
			
				objectFromPool.transform.position = _spawnPoint.position + new Vector3(0, Random.Range(-3f,3f),0);
				yield return _interval;
				_interval = new WaitForSeconds(Random.Range(1f, 3f));
			}
		}
	}
}