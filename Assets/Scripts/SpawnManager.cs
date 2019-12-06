using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private bool _stopSpawning;
    [SerializeField] private PowerUp _tripleShot;
    [SerializeField] private GameObject _tripleContainer;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (!_stopSpawning)
        {
            GameObject enemy = Instantiate(_enemy.gameObject, new Vector3(Random.Range(-9.3f, 9.3f), 6.5f, 0),
                Quaternion.identity);
            enemy.gameObject.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (!_stopSpawning)
        {
            PowerUp powerUp = Instantiate(_tripleShot, new Vector3(Random.Range(-9f, 9.3f), 6.5f, 0),
                Quaternion.identity);
            powerUp.gameObject.transform.parent = _tripleContainer.transform;
            float time = Random.Range(3, 7);
            yield return new WaitForSeconds(time);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}