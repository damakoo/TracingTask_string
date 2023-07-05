using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTensor : MonoBehaviour
{
    float tensor = 100000;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.inertia = tensor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
