using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ex01_FSM/EatState")]
public class Ex01_State_Eat : Ex01_State
{
    public float RestoreEat = 0.6f;
    public Ex01_State NoFoodState;

    Transform targetFood;

    public override void Init()
    {
        GameObject[] food = GameObject.FindGameObjectsWithTag("Food");

        if(food.Length == 0)
        {
            character.SetState(NoFoodState);
            return;
        }

        targetFood = food[Random.Range(0, food.Length)].transform;
    }

    public override void Run()
    {
        if (IsFinished) return;
        MoveToFood();
    }

    void MoveToFood()
    {
        float distance = (targetFood.position - character.transform.position).magnitude;

        if (distance > 1f) character.MoveTo(targetFood.position);
        else
        {
            Destroy(targetFood.gameObject);
            character.Eat += RestoreEat;
            IsFinished = true;
        }
    }
}
