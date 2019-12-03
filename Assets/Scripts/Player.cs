using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 3.5f;

    private Vector3 _position;

    [SerializeField] private GameObject _laserObject;

    [SerializeField] private float _fireRate = 0.15f;

    [SerializeField] private float _fireDelay = 0.0f;

    [SerializeField] private int _lives = 3;

    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, -3.5f, 0);
        _spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("Null Spawn Manager");
        }
        
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _fireDelay)
        {
            CreateLaser();
        }
    }

    private void CreateLaser()
    {
        _fireDelay = _fireRate + Time.time;
        Instantiate(_laserObject, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    private void CalculateMovement()
    {
        float getHorizontalInput = Input.GetAxis("Horizontal");
        float getVerticalInput = Input.GetAxis("Vertical");

        _position = new Vector3(getHorizontalInput, getVerticalInput, 0);
        transform.Translate(_position * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));

        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-11.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector3(11.0f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives--;
        
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}