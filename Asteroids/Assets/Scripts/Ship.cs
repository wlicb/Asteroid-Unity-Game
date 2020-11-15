using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Ship : MonoBehaviour
{

    #region Fields
    Rigidbody2D rigidbody2D;
    const float ThrustForce = 0.2f;
    
    Vector2 thrustDirection = new Vector2(1,0);
    const float RotateDegreesPerSecond = 75;

    [SerializeField]
    GameObject prefabBullet;

    public static bool dead = false;


    #endregion



    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
                rotationAmount *= -1;
            transform.Rotate(Vector3.forward, rotationAmount);
            float rotationz = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(rotationz);
            thrustDirection.y = Mathf.Sin(rotationz);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position, Quaternion.identity);
            Bullet script = bullet.GetComponent<Bullet>();
            script.ApplyForce(thrustDirection);
        }
    }


    void FixedUpdate()
    {
        
        if (Input.GetAxis("Thrust") != 0)
        {
            rigidbody2D.AddForce(ThrustForce * thrustDirection, ForceMode2D.Impulse);
        }
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Asteroid"))
        {
            HP.hp -= UnityEngine.Random.Range(1, 4);
            if (HP.hp <= 0)
            {
                dead = true;
                Destroy(gameObject);
            }

            

        }
            

    }


    #endregion
}