﻿using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
 
    void Update()
    {
        transform.Translate(Time.deltaTime * _speed * Vector3.down);

        if (transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.ActivateTripleShot();
            }
        }
    }
}
