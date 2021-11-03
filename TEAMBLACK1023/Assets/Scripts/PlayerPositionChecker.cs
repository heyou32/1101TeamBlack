using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾ ���� �������� ���Դ��� Ȯ���ϴ� ��ũ��Ʈ
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
        //�÷��̾ ���� �� 3�� �� ���� �ݰ�, ���ϸ��̼� ����
        if (stayTime > 3)
        {
           // portalClose.enabled = true;
            projectManager.s1Done = true;
        }
    }
}
