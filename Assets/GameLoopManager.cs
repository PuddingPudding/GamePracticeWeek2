using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public HUE_Rotate hueRotate;

    public void GameOver()
    {
        //DOTween.To可將第一個參數(你要改變的東西) 於指定時間內(指定時間為第四個參數) 轉變為第三個參數值
        //以下此行的意思為，讓時間快慢於1秒內轉變至0
        DOTween.To(() => Time.timeScale, (x) => Time.timeScale = x, 0, 1f).SetUpdate(true);

        //Fade有褪色之意，在這裡則代表著於1秒內(第二個參數為時間)將BGM音量調到0
        //後面補上OnComplete的意思為，定義DOFade結束後做什麼事，以這邊的例子來說，聲音降完後我們就把BGM停掉
        bgmAudioSource.DOFade(0, 1f).OnComplete(() =>
        {
            bgmAudioSource.Stop();
        }).SetUpdate(true);

        hueRotate.RotateValue = Mathf.PI;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
