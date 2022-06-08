using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Даёт возможность через Input переключать поведение NPC для теста
public class Ex02_SwitchBehavior : MonoBehaviour
{
    public Ex02_Character character;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) SetBehaviorWalk();
        else if (Input.GetKeyDown(KeyCode.E)) SetBehaviorEat();
        else if (Input.GetKeyDown(KeyCode.S)) SetBehaviorSleep();
    }

    void SetBehaviorWalk()
    {
        var behavior = character.GetBehavior<PlayerBehaviorWalk>();
        character.SetBehavior(behavior);
    }
    void SetBehaviorEat()
    {
        var behavior = character.GetBehavior<PlayerBehaviorEat>();
        character.SetBehavior(behavior);
    }

    void SetBehaviorSleep()
    {
        var behavior = character.GetBehavior<PlayerBehaviorSleep>();
        character.SetBehavior(behavior);
    }
}
