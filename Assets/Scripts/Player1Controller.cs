using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using UnityEngine.InputSystem;
using UnityEditor.U2D.Path.GUIFramework;

public class Player1Controller : MonoBehaviour
{
    public float speed = 5f;

    float inventorySlot = 0;

    public float maxHealth = 100f;

    public float turnSpeed = 1;

    [SerializeField] 
    float currentHealth;

    Rigidbody2D rb;

    public List<GameObject> selectedGuns = new List<GameObject>();

    public List<GameObject> inventory = new List<GameObject>();

    public GameObject gun;

    public GameObject gunLocation;

    public InputMaster controls;

    public Vector2 movementDirection;

    // Start is called before the first frame update
    void Awake()
    {

        controls = new InputMaster();
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        GameObject gameController = GameObject.Find("GameController");
        gameController.GetComponent<GameController>().players.Add(gameObject);
    }

    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new InputMaster();

        }
        controls.Player.Enable();
        controls.Player.Shoot.performed += Shoot_performed;
        controls.Player.Shoot.canceled += Shoot_canceled;

    }

    public void OnDisable()
    {

        controls.Player.Enable();
        controls.Player.Shoot.performed -= Shoot_performed;
        controls.Player.Shoot.canceled -= Shoot_canceled;

    }

    private void Start()
    {
        for (int i = 0; i < selectedGuns.Count; i++)
        {
            GameObject spawnedGun = Instantiate(selectedGuns[i], transform.position, transform.rotation, gameObject.transform);
            inventory.Add(spawnedGun);
            inventory[i].SetActive(false);
        }
        gun = inventory[0];
        gun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        OnRotate();
        OnwWeaponSelect();
        OnWeaponSelectIncrease();
        OnWeaponSelectDecrease();
        if (currentHealth <= 0)
        {
            Death();
        }

    }

    private void FixedUpdate()
    {
        OnMovement();
    }

    void OnMovement()
    {
        movementDirection = controls.Player.Movement.ReadValue<Vector2>();
        rb.velocity = movementDirection * speed;
    }

    void OnRotate()
    {
 
            float lookY = controls.Player.Rotate.ReadValue<Vector2>().y;
            float lookX = controls.Player.Rotate.ReadValue<Vector2>().x;
            float angle = Mathf.Atan2(lookY, lookX) * Mathf.Rad2Deg;

            Quaternion aimDirection = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.Log("angle: " + angle);
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, aimDirection, turnSpeed * Time.deltaTime);

    }

    void OnwWeaponSelect()
    {
        float weaponSelect = controls.Player.WeaponSelect.ReadValue<float>();


        if (weaponSelect > 0)
        {
            inventorySlot += 1;
            if (inventorySlot > inventory.Count - 1)
            {
                inventorySlot = 0;
            }
            Debug.Log(weaponSelect);
            WeaponSpawn();
            Debug.Log(inventorySlot);
        }


        if (weaponSelect < 0)
        {
            inventorySlot -= 1;

            if (inventorySlot < 0)
                inventorySlot = inventory.Count - 1;
            Debug.Log(weaponSelect);
            WeaponSpawn();
            Debug.Log(inventorySlot);
        }

        weaponSelect = 0;
    }

    void OnWeaponSelectIncrease()
    {
        inventorySlot += 1;
        if (inventorySlot > inventory.Count - 1)
        {
            inventorySlot = 0;
        }
        WeaponSpawn();
        Debug.Log(inventorySlot);
    }

    void OnWeaponSelectDecrease()
    {
        inventorySlot -= 1;

        if (inventorySlot < 0)
            inventorySlot = inventory.Count - 1;
        WeaponSpawn();
        Debug.Log(inventorySlot);
    }
    //This makes the player shoot when pressing the shoot button
    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        gun.GetComponent<gunScript>().shooting = true;
        if (gun.GetComponent<gunScript>().currentMagazineSize == 0)
        {
            StartCoroutine(gun.GetComponent<gunScript>().Reload());
        }

    }
    //This makes the player stop shooting with automatic weapons when releasing the button
    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        gun.GetComponent<gunScript>().shooting = false;

    }

    void WeaponSpawn()
    {
        gun.SetActive(false);
        gun = inventory[(int)inventorySlot];
        gun.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Death()
    {
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.players.Remove(gameObject);
        Destroy(gameObject);
    }
}
