using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentManagerScript : MonoBehaviour
{
    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    private void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayShootAnimation();
        }
    }
}
