using BBUnity.Actions;
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

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
        transform.rotation = new Quaternion(myX, myY, transform.rotation.z, 0);
        timeToAttack -= Time.deltaTime;

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
            FindClosestEnemy().GetComponent<Player1Controller>().TakeDamage(damage);
            timeToAttack = rateOfAttack;
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
