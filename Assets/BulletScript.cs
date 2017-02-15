using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private float _speed = 5;


    public void InitAndShoot(Vector2 direction)
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        _rigidbody2D.velocity = _speed * direction;
    }

    // Use this for initialization

    //void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {

    }
}
