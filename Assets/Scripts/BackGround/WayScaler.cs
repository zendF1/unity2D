using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer> ();
        Vector3 tempScale = transform.localScale;

        float height = Camera.main.orthographicSize;
        float width = sr.bounds.size.x;

        float positionHeight = -1 * height * 9 / 10;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width/Screen.height;
        
        tempScale.y = height / 2;
        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;

        transform.position = new Vector3(0, positionHeight, 0);

    }

}
