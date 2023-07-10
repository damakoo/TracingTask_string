using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor2 : MonoBehaviour
{
    public bool CollideDeadline = false;
    [SerializeField] TargetSystem _targetSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            _targetSystem.CollisionNumber += 1;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Deadline"))
        {
            CollideDeadline = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Deadline"))
        {
            CollideDeadline = true;
        }
    }
}
