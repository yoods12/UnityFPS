using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}

public class PlayerCtrl : MonoBehaviour
{
    // horizontal, vertical 받는 변수
    float h = 0f;
    float v = 0f;

    // transform 컴포넌트 받는 변수와 스피드 변수
    Transform tr;
    public float moveSpeed = 10f;
    
    // 마우스 움직임 받는 변수와 화면 움직임 변수
    float r = 0f;
    public float rotSpeed = 300f;

    // 애니메이션들을 받아놓는 클래스 변수와 애니메이션 컴포넌트를 사용하기 위한 변수 
    public PlayerAnim playerAnim;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); // transform 초기화 
        anim = GetComponent<Animation>(); // 애니메이션 컴포넌트 초기화
        anim.clip = playerAnim.idle; // 애니메이션 초기를 idle로 둠
        anim.Play(); // 해당 애니메이션 실행
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // 수직값 Z축
        v = Input.GetAxis("Vertical"); // 수평값 X축
        r = Input.GetAxis("Mouse X"); // 마우스 입력값

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); // 움직임을 담는 벡터

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self); //움직임을 줌
        tr.Rotate(Vector3.up * rotSpeed * r * Time.deltaTime); // 마우스의 이동에 따라 캐릭터가 회전함

        //애니메이션 처리
        if(v >= 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        }
        else if(h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        }
        else if(h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }
    }
}
