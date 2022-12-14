using System.Collections;
using Factories;
using UnityEngine;
using Zenject;

namespace Infrastructure.Bootstrap
{
    public class SceneSpawner : MonoBehaviour
    {
        [Header("Spawn zombie before the game starts")]
        
        [SerializeField] private int _countZombieForSpawn;
        [SerializeField] private float _spawnDelayInSeconds;
        
        private ZombieFactory _zombieFactory;

        [Inject]
        private void Construct(ZombieFactory zombieFactory, PlayerFactory playerFactory)
        {
            _zombieFactory = zombieFactory;
        }

        private void Awake()
        {
            StartCoroutine(SpawnZombies(_countZombieForSpawn, _spawnDelayInSeconds));
        }

        private IEnumerator SpawnZombies(int count, float delay)
        {
            int spawnedZombie = 0;
            while (spawnedZombie < count)
            {
                yield return new WaitForSeconds(delay);
                _zombieFactory.Create();
                spawnedZombie = spawnedZombie + 1;
            }
        }
    }
}