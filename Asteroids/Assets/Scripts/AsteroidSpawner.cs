using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject prefabAsteroid;
        
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GameObject asteroid = Instantiate(prefabAsteroid) as GameObject;
        CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
        float radius = collider.radius;
        Destroy(asteroid);

        asteroid = Instantiate(prefabAsteroid) as GameObject;
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Left, new Vector3(ScreenUtils.ScreenRight + radius, 0, -Camera.main.transform.position.z) );

        asteroid = Instantiate(prefabAsteroid) as GameObject;
        script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Right, new Vector3(ScreenUtils.ScreenLeft - radius, 0, -Camera.main.transform.position.z));

        asteroid = Instantiate(prefabAsteroid) as GameObject;
        script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Down, new Vector3(0, ScreenUtils.ScreenTop + radius, -Camera.main.transform.position.z));

        asteroid = Instantiate(prefabAsteroid) as GameObject;
        script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Up, new Vector3(0, ScreenUtils.ScreenBottom - radius, -Camera.main.transform.position.z));
    }


}
