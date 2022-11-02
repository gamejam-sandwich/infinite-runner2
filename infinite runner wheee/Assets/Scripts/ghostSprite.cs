using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSprite : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movement = Vector2.zero;
        if (Input.GetMouseButtonDown(0)) {
            rb.velocity = Vector2.up * speed;
            transform.position = new Vector2(mousePos.x, transform.position.y);
        }
    }
}
