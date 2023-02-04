using Modules.Lib2D.Runtime;
using UnityEngine;

public class Robot : CharacterController2D
{
    [SerializeField] private Transform target;
    void Start()
    {
        LookAt2D(target);
        MoveTo2D(target, callback:() => {Debug.Log("COUCOU");});
    }

}
