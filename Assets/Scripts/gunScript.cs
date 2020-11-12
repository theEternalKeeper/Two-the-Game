using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float rateOfFire = 1f;

    private float timeToFire = 0f;

    [SerializeField]
    float reloadTime = 5f;

    public float bulletDamage;

    public float currentSpread;

    public float maxSpread = 0.5f;

    public float spreadRate = 0.1f;

    public float spreadRecovery = 0.2f;

    public float maxMagazineSize;

    public float currentMagazineSize;

    public bool semiAuto;

    public bool shooting = false;

    public GameObject bullet;

    Vector2 shootDirection;


    // Start is called before the first frame update
    void Start()
    {
        currentMagazineSize = maxMagazineSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        currentSpread -= spreadRecovery * Time.deltaTime;
        if (currentSpread <= 0)
        {
            currentSpread = 0;
        }

        if (shooting == true)
        {
            Shoot();
        }

    }

    public void Shoot ()
    {
        if (semiAuto == true && currentMagazineSize > 0)
        {
            currentMagazineSize -= 1;
            shootDirection = gameObject.transform.up;
            shootDirection.x += Random.Range(-currentSpread, currentSpread);
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, shootDirection, 50f);
            Debug.DrawRay(gameObject.transform.parent.position, shootDirection, Color.red);
            if (hit)
            {

                Debug.Log(hit.collider.name);
                hit.transform.SendMessage("ApplyDamage", bulletDamage);

            }

            currentSpread += spreadRate;
            if (currentSpread >= maxSpread)
            {
                currentSpread = maxSpread;
            }

            shooting = false;
        }
        else if (semiAuto != true && Time.time >= timeToFire && currentMagazineSize > 0)
        {
            currentMagazineSize -= 1;
            shootDirection = gameObject.transform.up;
            shootDirection.x += Random.Range(-currentSpread, currentSpread);
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, shootDirection, 50f);
            Debug.DrawRay(gameObject.transform.parent.position, shootDirection, Color.red);
            if (hit)
            {

                Debug.Log(hit.collider.name);
                hit.transform.SendMessage("ApplyDamage", bulletDamage);
            }

            currentSpread += spreadRate;
            if (currentSpread >= maxSpread)
            {
                currentSpread = maxSpread;
            }
            timeToFire = Time.time + 1f / rateOfFire;
        };
    }

    public IEnumerator Reload()
    {
        for (float i = 0; i < reloadTime; i ++)
        {
            yield return new WaitForSeconds(1f);
        }
        currentMagazineSize = maxMagazineSize;
    }

    /*        GameObject projectile = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        BulletScript bulletScript = projectile.GetComponent<BulletScript>();
        bulletScript.bulletDamage = bulletDamage;*/
}
