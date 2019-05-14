using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackEnemyController : BaseEnemyController
{
    public float safeRange;
    public GameObject shotPrefab;
    public float shotCadenceTimer;
    private Coroutine shooting;
    public float bulletSpeed;
    private bool playerTooclose;
    public bool kiting;
    public float kitingShootingSlowRate;

    protected override void Update()
    {
        base.Update();
        player = DetectObjectsAround();

        if (player != null)
        {
            playerTooclose = Vector2.Distance(transform.position,
                                        player.transform.position) < safeRange;
            target = player.transform.position;

            if (playerTooclose)
            {
                transform.position = Vector2.MoveTowards(transform.position, target,
                 -1 * speed * Time.deltaTime);
                if (kiting && shooting == null)
                {
                    shooting = StartCoroutine(FireAtPlayer(player.transform.position));
                }
            }
            else
            {
                if (shooting == null)
                {
                    shooting = StartCoroutine(FireAtPlayer(player.transform.position));
                }
            }
        }
    }

    private IEnumerator FireAtPlayer(Vector3 position)
    {
        GameObject shot = Instantiate(shotPrefab);
        shot.transform.position = eyes.position;
        shot.GetComponent<ShotController>().Initialize(position, bulletSpeed);
        yield return new WaitForSeconds(playerTooclose ? shotCadenceTimer * kitingShootingSlowRate : shotCadenceTimer);
        shooting = null;
    }
}
