using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGoal : MonoBehaviour
{   
    [SerializeField] Transform goal;

    void Update()
    {
        Observar();
    }

    private void Observar()
    {
        RotateZ(LookAtOMG(goal.position - transform.position));
    }

    private float LookAtOMG(Vector2 target)
    {
        float direccion = Mathf.Atan2(target.y, target.x);
        return (direccion);
    }


    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
