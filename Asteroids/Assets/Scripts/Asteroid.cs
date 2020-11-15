using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    Sprite greenAsteroidSprite;
    [SerializeField]
    Sprite magentaAsteroidSprite;
    [SerializeField]
    Sprite whiteAsteroidSprite;



    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = UnityEngine.Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = greenAsteroidSprite;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = magentaAsteroidSprite;
        }
        else
        {
            spriteRenderer.sprite = whiteAsteroidSprite;
        }
   
    }

    public void Initialize(Direction direction, Vector3 position)
    {
        transform.position = position;
        // set random angle based on direction
        float angle;
        float randomAngle = UnityEngine.Random.value * 30f * Mathf.Deg2Rad;
        if (direction == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }

        // apply impulse force to get game object moving
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Restart.gameLevel;
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            Score.score += 1; // NullReferenceException: Object reference not set to an instance of an object
                               // Asteroid.OnCollisionEnter2D(UnityEngine.Collision2D coll)
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
        
    }
}
