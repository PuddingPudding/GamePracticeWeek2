using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private float _speed = 2;

    const float flashDuration = 0.1f; //閃爍間隔
    float flashCounter = 0;

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

        float rotationZ = Mathf.Atan2(_rigidbody2D.velocity.y, _rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        //Atan2可取得 "幾弧度" ，算出tan(y/x)的弧度，Mathf.Rad2Deg可取得 1弧度 為幾度
        Debug.Log(rotationZ);
        this.transform.eulerAngles = new Vector3(0, 0, rotationZ);
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            _spriteRenderer.color = Color.white;
        }
        else
        {
            _spriteRenderer.color = Color.green;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        flashCounter = flashDuration;
    }
}
