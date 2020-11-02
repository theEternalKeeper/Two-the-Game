using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 5f;

    float inventorySlot = 0;

    /*public float rateOfFire = 2f;

    public float timeOfFire = 3f;

    public float bulletForce = 200f;

    public GameObject bullet; */

    CharacterController playerController;

    public List<GameObject> inventory = new List<GameObject>();

    public GameObject gun;

    public GameObject gunLocation;



    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        gun = Instantiate (inventory[0], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += Vector3.up * Input.GetAxis("Vertical")* speed * Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

       /* if (Input.GetButton("Fire1") && timeOfFire >= rateOfFire)
        {
            GameObject projectile = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(projectile.transform.up * bulletForce);
            timeOfFire = 0;
        }
        timeOfFire += Time.deltaTime; */
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            inventorySlot += 1;
            if (inventorySlot >= inventory.Count)
            {
                inventorySlot = 0;
            }
            Destroy(gun);
            gun = Instantiate(inventory[(int)inventorySlot], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
            Debug.Log(inventorySlot);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            inventorySlot -= 1;
            if (inventorySlot < 0)
            {
                inventorySlot = inventory.Count-1;
            }
            Destroy(gun);
            gun = Instantiate(inventory[(int)inventorySlot], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
            Debug.Log(inventorySlot);
        }
    }
}
