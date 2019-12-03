using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    void Start()
    {
    }

    void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y >= 8.0f)
        {
            Destroy(this.gameObject);
        }
    }
}