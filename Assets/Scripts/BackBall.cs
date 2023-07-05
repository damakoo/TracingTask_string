using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBall : MonoBehaviour
{
    [SerializeField] Transform pos;
    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.transform.position.x > this.transform.position.x)
        {
            _rigidbody2D.AddForce(new Vector3(30000000000000000f, 0, 0));
        }
    }
}
