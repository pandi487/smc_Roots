using System;
using UnityEngine;
using Modules.Lib2D.Runtime;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CharBehavior : CharacterController2D
{
    private GameObject tarBody;
    public float speed = 1f;
    [SerializeField] private Transform target;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-16f, 16f), Random.Range(-10f, 2f), 0);
        tarBody = new GameObject();
        target = tarBody.transform;
        MoveToNewTarget();
    }

    void MoveToNewTarget()
    {
        NewPos();
        flip(target.position.x < transform.position.x);
        MoveTo2D(target, speed, callback:MoveToNewTarget);
    }

    void NewPos()
    {
        target.position = new Vector3(Random.Range(-16f, 16f), Random.Range(-10f, 3f), 0);
    }

    void flip(bool left)
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
            sprite.flipX = !left;
    }
    void FixedUpdate()
    {
        base.FixedUpdate();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
