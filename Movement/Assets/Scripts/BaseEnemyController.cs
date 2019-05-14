using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    //public EnemyType type;
    protected bool moving, soundAlreadyPlayed;
    public Transform eyes;
    public List<Transform> allies = new List<Transform>();
    protected Collider2D player;
    protected bool followTeam;
    protected bool leader;
    protected Vector2 target = Vector2.zero;
    public float playerDetectionRange;
    public int spawnPoint;
    public SpriteRenderer spriteRenderer;
    //public EnemyDataDisplayController enemyDataDisplayController;
    protected Coroutine clearTextsRoutine;
    public bool facingRight = true;
    Transform tar;

    protected virtual void Awake()
    {
        moving = false;
    }

    public virtual void Initialize(int bonusDamage, int bonusHealth, 
        float bonusSpeed, int spawnPoint)
        //EnemyDataDisplayController enemyDataDisplayController)
    {
        //this.enemyDataDisplayController = enemyDataDisplayController;
        damage += bonusDamage;
        health += bonusHealth;
        speed += bonusSpeed;
        this.spawnPoint = spawnPoint;
    }

    protected virtual void Update()
    {
        if (health <= 0)
        {
            Dead();
        }

    }

    public virtual Collider2D DetectObjectsAround()
    {
        Collider2D[] surroundingObjects = Physics2D.OverlapCircleAll(transform.position, playerDetectionRange);
        allies.Clear();
        Collider2D player = null;
        for (int i = 0; i < surroundingObjects.Length; i++)
        {
            if (surroundingObjects[i].CompareTag("Enemy"))
            {
                allies.Add(surroundingObjects[i].transform);
            }
            if (surroundingObjects[i].CompareTag("Player"))
            {
                //tar = surroundingObjects[i].transform;
                //if(tar.position.x > 


                if (!soundAlreadyPlayed)
                {
                    PlayDetectedSound();
                }
                
                player = surroundingObjects[i];
            }
        }
        soundAlreadyPlayed = player != null;
        return player;
    }

    protected virtual void PlayDetectedSound()
    {
        //AudioManager.instance.PlayDetectedSound();
    }

    protected virtual void Dead()
    {
       // EnemyManager.instance.SubstituteEnemy(this);
        Destroy(gameObject);
    }

    protected virtual void OnMouseEnter()
    {
        if (clearTextsRoutine != null) StopCoroutine(clearTextsRoutine);
        //enemyDataDisplayController.SetupTexts(this);
    }

    protected virtual void OnMouseExit()
    {
      clearTextsRoutine = StartCoroutine(ClearTexts());
    }

    protected virtual IEnumerator ClearTexts()
    {
        yield return new WaitForSeconds(3);
       // enemyDataDisplayController.ClearTexts();
        clearTextsRoutine = null;
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingRight = !facingRight;
    }
}
