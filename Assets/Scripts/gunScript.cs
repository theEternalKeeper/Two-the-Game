using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float rateOfFire = 1f;

    private float timeToFire = 0f;

    public float bulletDamage;

    public float currentSpread;

    public float maxSpread = 0.5f;

    public float spreadRate = 0.1f;

    public float spreadRecovery = 0.2f;

    public bool semiAuto;

    public GameObject bullet;

    Vector2 shootDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (semiAuto == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else if (semiAuto != true)
        {
            if (Input.GetButton("Fire1") && Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1f / rateOfFire;
                Shoot();
            }
        };

        currentSpread -= spreadRecovery * Time.deltaTime;
        if (currentSpread <= 0)
        {
            currentSpread = 0;
        }

    }

    void Shoot ()
    {

        shootDirection = gameObject.transform.up;
        shootDirection.x += Random.Range(-currentSpread, currentSpread);
        shootDirection.y += Random.Range(-currentSpread, currentSpread);
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, shootDirection, 50f);
        Debug.DrawRay(gameObject.transform.position, shootDirection, Color.red);
        if (hit)
        {

            Debug.Log(hit.collider.name);
            hit.transform.SendMessage("ApplyDamage", bulletDamage);
            hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
        }
 
        currentSpread += spreadRate;
        if (currentSpread >= maxSpread)
        {
            currentSpread = maxSpread;
        }
    }

    /*        GameObject projectile = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        BulletScript bulletScript = projectile.GetComponent<BulletScript>();
        bulletScript.bulletDamage = bulletDamage;*/
}
