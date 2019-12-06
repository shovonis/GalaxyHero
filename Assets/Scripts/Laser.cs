using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        transform.Translate(Time.deltaTime * _speed * Vector3.up);

        if (transform.position.y >= 8.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}