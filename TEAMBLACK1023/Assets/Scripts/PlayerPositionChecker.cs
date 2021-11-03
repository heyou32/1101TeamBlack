using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어가 다음 공간으로 들어왔는지 확인하는 스크립트
public class PlayerPositionChecker : MonoBehaviour
{
    public GameObject playerCollider;

    public float stayTime;

    //public PortalClose portalClose;

    public ProjectManger projectManager;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerCollider.gameObject)
            stayTime += Time.deltaTime;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerCollider)
            stayTime = 0;
    }
    private void Update()
    {
        //플레이어가 들어온 후 3초 후 포털 닫고, 에니메이션 시작
        if (stayTime > 3)
        {
           // portalClose.enabled = true;
            projectManager.s1Done = true;
        }
    }
}
