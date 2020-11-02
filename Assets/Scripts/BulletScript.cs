using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Enemy")
        {
            Other.gameObject.SendMessage("ApplyDamage", bulletDamage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
