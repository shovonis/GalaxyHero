using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 4.0f;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-9.3f, 9.3f), 6.5f, 0);
    }

    void Update()
    {
        transform.Translate(_enemySpeed * Time.deltaTime * Vector3.down);
        
        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(Random.Range(-9.3f, 9.3f), 6.5f, 0);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}