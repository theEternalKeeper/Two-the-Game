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

    Rigidbody2D rb;

    public List<GameObject> inventory = new List<GameObject>();

    public GameObject gun;

    public GameObject gunLocation;

    public InputMaster controls;

    public Vector2 movementDirection;

    // Start is called before the first frame update
    void Awake()
    {
        gun = Instantiate(inventory[0], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
        controls = new InputMaster();
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        
    }

    // Update is called once per frame
    void Update()
    {

        OnRotate();
        OnwWeaponSelect();


        //This block allows the player to change weapon


    }

    private void FixedUpdate()
    {
;

        OnMovement();

    }

    void OnMovement()
    {
        movementDirection = controls.Player.Movement.ReadValue<Vector2>();
        rb.velocity = movementDirection * speed;
    }

    void OnRotate()
    {
        Vector2 mousePosition = controls.Player.Rotate.ReadValue<Vector2>();

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - rb.position);
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
            Destroy(gun);
            gun = Instantiate(inventory[(int)inventorySlot], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
            Debug.Log(inventorySlot);
        }


        if (weaponSelect < 0)
        {
            inventorySlot -= 1;

            if (inventorySlot < 0)
                inventorySlot = inventory.Count - 1;
            Debug.Log(weaponSelect);
            Destroy(gun);
            gun = Instantiate(inventory[(int)inventorySlot], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
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
        Destroy(gun);
        gun = Instantiate(inventory[(int)inventorySlot], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
        Debug.Log(inventorySlot);
    }

    void OnWeaponSelectDecrease()
    {
        inventorySlot -= 1;

        if (inventorySlot < 0)
            inventorySlot = inventory.Count - 1;
        Destroy(gun);
        gun = Instantiate(inventory[(int)inventorySlot], gunLocation.transform.position, gunLocation.transform.rotation, gunLocation.transform);
        Debug.Log(inventorySlot);
    }
    //This makes the player shoot when pressing the shoot button
    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        gun.GetComponent<gunScript>().shooting = true;

    }
    //This makes the player stop shooting with automatic weapons when releasing the button
    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        gun.GetComponent<gunScript>().shooting = false;

    }


}
