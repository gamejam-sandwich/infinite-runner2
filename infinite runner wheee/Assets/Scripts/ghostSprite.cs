using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ghostSprite : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 boundary;
    int life = 5;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        Vector2 bodySize = new Vector2(
            sr.size.x * transform.localScale.x,
            sr.size.y * transform.localScale.y
            );
        Vector2 cameraSize = GetCameraSize();
        boundary = new Vector2(
            (cameraSize.x - bodySize.x) / 2,
            (cameraSize.y - bodySize.y) / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) {
            Destroy(GameObject.FindGameObjectWithTag("fence"));
            rb.gravityScale = 10;
            return;
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movement = Vector2.zero;
        if (Input.GetMouseButtonDown(0))
        {
            float x;
            rb.velocity = Vector2.up * speed;
            if (mousePos.x < -boundary.x) {
                x = -boundary.x;
            }
            else if (mousePos.x > boundary.x) {
                x = boundary.x;
            }
            else {
                x = mousePos.x;
            }
            transform.position = new Vector2(x, transform.position.y);
            
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fence"))
        {
            life--;
            if (life == 0) dead = true;
        }
    }

    Vector2 GetCameraSize() {
        Camera cam = Camera.main;
        float h = 2f*cam.orthographicSize;
        return new Vector2(h * cam.aspect, h);
    }
}
