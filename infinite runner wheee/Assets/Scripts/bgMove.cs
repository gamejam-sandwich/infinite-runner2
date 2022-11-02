using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{

    public float speed;
    float groundLength;

    SpriteRenderer ground;

    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<SpriteRenderer>();
        groundLength = ground.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y - speed * Time.deltaTime);

        if (transform.position.y <= -groundLength) {
            transform.position = new Vector2(
                transform.position.x,
                transform.position.y + 2 * groundLength);
        }
    }
}
