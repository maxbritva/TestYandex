using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Pool
{
	public class GameObjectPool : MonoBehaviour
	{
		[SerializeField] private GameObject _prefabEnemy;
		[SerializeField] private GameObject _prefabBonus;
		[SerializeField] private int _startCount;
		[SerializeField] private List<GameObject> _poolEnemy;
		[SerializeField] private List<GameObject> _poolBonus;
		[Inject] private DiContainer _diContainer;

		private void Awake()
		{
			PoolInitialize(_prefabEnemy, _poolEnemy);
			PoolInitialize(_prefabBonus, _poolBonus);
		}
		
		public GameObject GetObjectFromPool(bool isEnemy)
		{
			GameObject targetPrefab = _prefabBonus;
			List<GameObject> targetPool = _poolBonus;
			if (isEnemy)
			{
				targetPool = _poolEnemy;
				targetPrefab = _prefabEnemy;
			}
			for (int i = 0; i < targetPool.Count; i++) 
			{
				if (targetPool[i].gameObject.activeInHierarchy == false) {
					targetPool[i].gameObject.SetActive(true);
					return targetPool[i]; 
				}
			}
			GameObject newObject = SpawnObject(targetPrefab, targetPool);
			newObject.gameObject.SetActive(true);
			return newObject;
		}

		private void PoolInitialize(GameObject targetPrefab, List<GameObject> targetPool) 
		{
			for (int i = 0; i < _startCount; i++) {
				SpawnObject(targetPrefab, targetPool);
			}
		}

		private GameObject SpawnObject(GameObject targetPrefab, List<GameObject> targetPool) 
		{
			GameObject newObject = _diContainer.InstantiatePrefab(targetPrefab, transform);
			targetPool.Add(newObject);
			newObject.gameObject.SetActive(false);
			return newObject;
		}
	}
	
	
}