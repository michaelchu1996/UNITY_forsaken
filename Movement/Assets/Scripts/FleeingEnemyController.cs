using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingEnemyController : BaseEnemyController
{
    protected override void Update()
    {
        base.Update();
        if (!followTeam || leader)
        {
            player = DetectObjectsAround();
            if (player != null)
            {
                moving = true;
                CallToArms();
            }
            else
            {
                StopChasing();
                moving = false;
            }
        }      

        if (moving)
        {
            target = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target,
                (allies.Count < 3 ? -1 : 1) * speed * Time.deltaTime);
        }
    }

    public void CallToArms()
    {
        leader = true;
        foreach(Transform ally in allies)
        {
            if (ally.GetComponent<FleeingEnemyController>())
            {
                ally.GetComponent<FleeingEnemyController>().moving = true;
                ally.GetComponent<FleeingEnemyController>().player = player;
                ally.GetComponent<FleeingEnemyController>().followTeam = true;
            }
        }
    }

    public void StopChasing()
    {
        leader = false;
        foreach (Transform ally in allies)
        {
            if (ally.GetComponent<FleeingEnemyController>())
            {
                ally.GetComponent<FleeingEnemyController>().moving = false;
                ally.GetComponent<FleeingEnemyController>().player = null;
                ally.GetComponent<FleeingEnemyController>().followTeam = false;
            }
        }
    }
}
