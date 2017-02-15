using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private float _speed = 2;


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
        //Vector的normalized (一般化) 會維持你向量的比例，但是會把其長度變成1
        if (_rigidbody2D.velocity == Vector2.zero)
        {
            //確保沒有人停下來
            _rigidbody2D.velocity = new Vector2(Random.Range(0, 1.0f), Random.Range(0, 1.0f)).normalized * _speed;
        }
        else
        {
            //確保碰撞後速度不變
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _speed;
        }
    }
}
