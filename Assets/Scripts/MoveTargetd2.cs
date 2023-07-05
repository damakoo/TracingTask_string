using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget2 : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public Vector3 startpos { get; set; }
    public float velocity { get; set; }
    public Vector3 direction { get; set; }

    public void Initialize(Vector3 _startpos, float _velocity, Vector3 _direction)
    {
        startpos = _startpos;
        velocity = _velocity;
        direction = _direction;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ignition()
    {
        this.transform.position = startpos;
        _rigidbody.velocity = direction * velocity;
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

}
