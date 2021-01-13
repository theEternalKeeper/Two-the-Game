using BBUnity.Actions;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 10;

    public float currentHealth;

    public float damage = 10;

    public float rateOfAttack = 5f;

    float timeToAttack;

    private float myX = 0f;
    private float myY = 0f;
    public float myZ;

    Animator animator;

    BehaviorExecutor beha;


    private void Awake()
    {
        currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animator>();
        beha = gameObject.GetComponent<BehaviorExecutor>();
    }

    private void Update()
    {
        var target = GetComponent<NavMeshAgent>().nextPosition;
        Vector3 lookDirection = Vector3.RotateTowards(transform.position, target, 0.0f, 0.0f);
        if (currentHealth <= 0)
        {
            Death();
        }
        timeToAttack -= Time.deltaTime;
        float lookY = lookDirection.y;
        float lookX = lookDirection.x;
        float angle = Mathf.Atan2(lookY, lookX) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, angle));
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Death()
    {
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public void Attack()
    {        
        if (timeToAttack <= 0)
        {
            FindClosestEnemy();
            animator.SetBool("IsAttacking", true);
            FindClosestEnemy().GetComponent<Player1Controller>().TakeDamage(damage);
            timeToAttack = rateOfAttack;
            animator.SetBool("IsAttacking", false);
        }

    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
