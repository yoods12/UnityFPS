using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // ī�޶� ���󰡴� ���
    public float moveDamping = 15f; //ī�޶� �����̴� �ӵ�
    public float rotateDamping = 10f; // ȸ���Ҷ� ȸ���ϴ� �ӵ�
    public float distance = 5f; // ������κ��� ī�޶� ���η� �󸶳� ������ �ִ���
    public float height = 4f;// ������κ��� ī�޶� ���η� �󸶳� ������ �ִ��� 
    public float targetOffset = 2f; // �Ǻ��� �߳��� �ֱ⿡ ī�޶� �� �� �ø��� ����

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); // �ڱ��ڽ��� ��ġ������ ������

    }

    // Update is called once per frame
    void LateUpdate()
    {
        var camPos = target.position //����� ��ġ����
                  - (target.forward * distance) // �ڷ� distance��ŭ
                  + (target.up * height); // height��ŭ ���� ��

        tr.position = Vector3.Slerp(tr.position, camPos, moveDamping * Time.deltaTime); // ĳ������ �������� ����
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, rotateDamping * Time.deltaTime); //ĳ������ ȸ���� ���� ȸ����

        tr.LookAt(target.position + (target.up * targetOffset)); // �Ǻ��� �߳��� �ֱ⿡ ī�޶� �� �� �ø��� ����
    }


}
