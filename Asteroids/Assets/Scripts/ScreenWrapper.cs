using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    #region Fields
    float radiusOfCollider;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        radiusOfCollider = GetComponent<CircleCollider2D>().radius;
    }

    void OnBecameInvisible()
    {
        Vector2 position = transform.position;
        if (position.x - radiusOfCollider > ScreenUtils.ScreenRight ||
            position.x + radiusOfCollider < ScreenUtils.ScreenLeft)
            position.x *= -1;
        else if (position.y - radiusOfCollider > ScreenUtils.ScreenTop ||
            position.y + radiusOfCollider < ScreenUtils.ScreenBottom)
            position.y *= -1;
        transform.position = position;
    }

    #endregion
}
