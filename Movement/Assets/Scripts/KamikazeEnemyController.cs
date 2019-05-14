using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemyController : BaseEnemyController
{
    protected override void Update()
    {
        base.Update();
        player = DetectObjectsAround();
        if (player != null)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            target = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target,
                 speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //collision.collider.GetComponent<PlayerCharacterController>().Damage(damage);
            //EnemyManager.instance.SubstituteEnemy(this);
            //Destroy(gameObject);
        }
    }

}
