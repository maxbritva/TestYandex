using Core.Score;
using UnityEngine;
using Zenject;

namespace Core.GameManager
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private ScoreCollector _scoreCollector;
		[SerializeField] private Player.Player _player;
		public override void InstallBindings()
		{
			Container.Bind<Player.Player>().FromInstance(_player).AsSingle().NonLazy();
			Container.Bind<ScoreCollector>().FromInstance(_scoreCollector).AsSingle().NonLazy();
		}
	}
}