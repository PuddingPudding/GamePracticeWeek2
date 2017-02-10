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

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    private void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
        GameCamera.transform.DOShakePosition(CameraShakeDuration, CameraShakeStrength);  //再開砲後呼叫DOTween套件中的DOShakePosition，做出震盪效果
    }

    private void PlayRotateAnimation()
    {
        float targetDegree = (360.0f / DirectionCount) * Random.Range(0, DirectionCount); //從8個方位中選出隨機的一個方位
        this.transform.DORotate(new Vector3(0, 0, targetDegree), rotateDuration); //選定角度(即方位)後，呼叫DOTween套件中的DoRotate方法進行旋轉
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayShootAnimation();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayRotateAnimation();
        }
    }
}
