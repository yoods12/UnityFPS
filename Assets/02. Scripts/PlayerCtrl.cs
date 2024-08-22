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
    // horizontal, vertical �޴� ����
    float h = 0f;
    float v = 0f;

    // transform ������Ʈ �޴� ������ ���ǵ� ����
    Transform tr;
    public float moveSpeed = 10f;
    
    // ���콺 ������ �޴� ������ ȭ�� ������ ����
    float r = 0f;
    public float rotSpeed = 300f;

    // �ִϸ��̼ǵ��� �޾Ƴ��� Ŭ���� ������ �ִϸ��̼� ������Ʈ�� ����ϱ� ���� ���� 
    public PlayerAnim playerAnim;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); // transform �ʱ�ȭ 
        anim = GetComponent<Animation>(); // �ִϸ��̼� ������Ʈ �ʱ�ȭ
        anim.clip = playerAnim.idle; // �ִϸ��̼� �ʱ⸦ idle�� ��
        anim.Play(); // �ش� �ִϸ��̼� ����
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // ������ Z��
        v = Input.GetAxis("Vertical"); // ���� X��
        r = Input.GetAxis("Mouse X"); // ���콺 �Է°�

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); // �������� ��� ����

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self); //�������� ��
        tr.Rotate(Vector3.up * rotSpeed * r * Time.deltaTime); // ���콺�� �̵��� ���� ĳ���Ͱ� ȸ����

        //�ִϸ��̼� ó��
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
