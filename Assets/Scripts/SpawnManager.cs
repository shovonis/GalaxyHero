using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            GameObject enemy = Instantiate(_enemy.gameObject, new Vector3(Random.Range(-9.3f, 9.3f), 6.5f, 0),
                Quaternion.identity);
            enemy.gameObject.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}