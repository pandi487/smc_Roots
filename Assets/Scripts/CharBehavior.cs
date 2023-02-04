using UnityEngine;
using Modules.Lib2D.Runtime;

public class CharBehavior : CharacterController2D
{
    public bool isFather = false;
    private GameObject tarBody;
    [SerializeField] private Transform target;
    void Start()
    {
        tarBody = new GameObject();
        target = tarBody.transform;
        MoveToNewTarget();
    }

    void MoveToNewTarget()
    {
        NewPos();
        flip(target.position.x < transform.position.x);
        MoveTo2D(target, callback:MoveToNewTarget);
    }

    void NewPos()
    {
        target.position = new Vector3(Random.Range(-20f, 20f), Random.Range(-10f, 10f), 0);
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
