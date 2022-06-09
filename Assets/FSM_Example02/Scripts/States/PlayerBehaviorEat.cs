using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorEat : IPlayerBehavior
{
    public bool IsInitialized { get; set; }
    public bool IsFinished { get; set; }
    public Ex02_Character character { get; set; }

    public float RestoreEat = 0.6f;
    public Ex01_State NoFoodState;

    Transform targetFood;

    public void Enter()
    {
        Debug.Log("Enter state Eat");

        GameObject[] food = GameObject.FindGameObjectsWithTag("Food");

        if (food.Length == 0)
        {
            character.SetBehavior(character.GetBehavior<PlayerBehaviorWalk>());
            return;
        }

        targetFood = food[Random.Range(0, food.Length)].transform;

        IsInitialized = true;
        IsFinished = false;
    }

    public void Update()
    {
        Debug.Log("Update state Eat");
        MoveToFood();

        // если это состояние закончило выполняться, выходим из этого состояния
        if (IsFinished) { Exit(); return; }
    }

    public void Exit()
    {
        Debug.Log("Exit state Eat");

        if (character.Eat <= 0.4f) character.SetBehavior(character.GetBehavior<PlayerBehaviorEat>());
        else if (character.Energy <= 0.4f) character.SetBehavior(character.GetBehavior<PlayerBehaviorSleep>());
        else character.SetBehavior(character.GetBehavior<PlayerBehaviorWalk>());
    }

    void MoveToFood()
    {
        float distance = (targetFood.position - character.transform.position).magnitude;

        if (distance > 1f) character.MoveTo(targetFood.position);
        else
        {
            GameObject.Destroy(targetFood.gameObject);
            character.Eat += RestoreEat;
            IsFinished = true;
        }
    }
}
