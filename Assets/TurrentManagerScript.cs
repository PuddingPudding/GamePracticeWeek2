using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurrentManagerScript : MonoBehaviour
{
    private Animator _animator;

    const int DirectionCount = 8; //將旋轉的方向切為8等分 (360度切成八塊)
    public Ease RotateEaseFunction; //用於決定旋轉時的補間動畫效果
    public float rotateDuration = 0.4f; //旋轉間隔

    public Camera GameCamera; //遊戲畫面
    public float CameraShakeDuration; //震盪間隔
    public float CameraShakeStrength; //震盪強度

    public GameObject bulletCandidate;  //子彈物件
    private float bulletOffset = 0.6f;  //子彈射出來時跟炮管的起始距離

    public ScoreManager scoreManager;
    public GameLoopManager gameLoopManager;

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    public void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
        GameCamera.transform.DOShakePosition(CameraShakeDuration, CameraShakeStrength);
        //以上此行在開砲後呼叫DOTween套件中的DOShakePosition，做出震盪效果

        scoreManager.AddScore(1);
        GameObject bulletobj = GameObject.Instantiate(bulletCandidate);
        BulletScript bulletScript = bulletobj.GetComponent<BulletScript>();
        bulletScript.transform.position = this.transform.position + bulletOffset * this.gameObject.transform.right;
        bulletScript.transform.rotation = this.transform.rotation;
        Vector3 shootDirection3D = this.gameObject.transform.right;
        Vector2 shootDirection2D = new Vector2(shootDirection3D.x, shootDirection3D.y);
        bulletScript.InitAndShoot(shootDirection2D);

        gameLoopManager.bullets.Add(bulletScript);
    }

    public void PlayRotateAnimation()
    {
        float targetDegree = (360.0f / DirectionCount) * Random.Range(0, DirectionCount); //從8個方位中選出隨機的一個方位
        this.transform.DORotate(new Vector3(0, 0, targetDegree), rotateDuration); //選定角度(即方位)後，呼叫DOTween套件中的DoRotate方法進行旋轉
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayShootAnimation();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    PlayRotateAnimation();
        //}
    }
}
