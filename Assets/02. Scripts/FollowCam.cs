using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // 카메라가 따라가는 대상
    public float moveDamping = 15f; //카메라가 움직이는 속도
    public float rotateDamping = 10f; // 회전할때 회전하는 속도
    public float distance = 5f; // 대상으로부터 카메라가 가로로 얼마나 떨어져 있는지
    public float height = 4f;// 대상으로부터 카메라가 세로로 얼마나 떨어져 있는지 
    public float targetOffset = 2f; // 피봇이 발끝에 있기에 카메라를 좀 더 올리기 위함

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); // 자기자신의 위치정보를 가져옴

    }

    // Update is called once per frame
    void LateUpdate()
    {
        var camPos = target.position //대상의 위치에서
                  - (target.forward * distance) // 뒤로 distance만큼
                  + (target.up * height); // height만큼 위로 감

        tr.position = Vector3.Slerp(tr.position, camPos, moveDamping * Time.deltaTime); // 캐릭터의 움직임을 따라감
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, rotateDamping * Time.deltaTime); //캐릭터의 회전에 따라 회전함

        tr.LookAt(target.position + (target.up * targetOffset)); // 피봇이 발끝에 있기에 카메라를 좀 더 올리기 위함
    }


}
