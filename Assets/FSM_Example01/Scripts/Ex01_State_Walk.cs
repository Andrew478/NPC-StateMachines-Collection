using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ex01_FSM/WalkState")]
public class Ex01_State_Walk : Ex01_State
{
    public float MaxDistance = 5f;

    Vector3 randomPosition;

    public override void Init()
    {
        Vector3 randomed = new Vector3(Random.Range(-MaxDistance, MaxDistance), 0f, Random.Range(-MaxDistance, MaxDistance));
        randomPosition = character.transform.position + randomed;
    }

    public override void Run()
    {
        float distance = (randomPosition - character.transform.position).magnitude;
        if (distance > 0.5f) character.MoveTo(randomPosition);
        else IsFinished = true;
    }
}
