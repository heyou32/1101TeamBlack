using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ProjectManger : MonoBehaviour
{
    public GameObject player;
    public Camera playerMainCamera;
    public List<GameObject> testPlayers = new List<GameObject>();
    List<Transform> rePositions = new List<Transform>();


    [Header("S0")]
    public GameObject s0;
    PlayableDirector s1Timline;
    public bool s0Done;

    [Header("S1")]
    public GameObject s1;
    PlayableDirector s2Timline;
    public Transform startPositions;
    bool isReLocationed;
    public bool s1Done;

    [Header("S2")]
    public GameObject s2;
    public GameObject rigthHandPrefab;
    public GameObject Rrobot;
    Animator rrobotAnim;


    void Start()
    {
        Setting_S1();
        Setting_S2();
    }

    void Update()
    {
        if (s0Done)
            Play_S1();

        if (s1Done)
            Play_S2();

    }
    #region S1 Functions
    void Setting_S1()
    {
        //S1�� Ÿ�Ӷ����� ������
        s1Timline = s1.GetComponent<PlayableDirector>();
        s1Timline.enabled = false;


        for (int i = 0; i < startPositions.childCount; i++)
        {
            rePositions.Add(startPositions.GetChild(i));
        }
    }
    void Play_S1()
    {
        s0.SetActive(false);

        //�÷��̾� ��ġ ���ġ�ϰ�
        PlayersReLocation();
        //S1 ���ϸ��̼� ����
        Invoke("PlayS1Timeline", 1);
    }
    void PlayersReLocation()
    {
        //���� �÷��̾ �ƹ�Ÿ ���� ��, �������� ���� ���������� ���̷� ���� ���� ����Ʈȭ �ؾ���.

        if (!isReLocationed)
        {
            //ī�޶� ������� ȿ��.  //�����ؾ��ҵ�
            playerMainCamera.cullingMask = 0;



            //�÷��̾� ��ġ �������� ���ġ

            //for (int i = 0; i < playerList.Count; i++)
            //{
            //    playerList[i].transform.position=rePositions[r].position;
            //playerList[i].transform.rotation = rePositions[r].rotation;

            //    rePositions.RemoveAt(r);
            //}

            //�׽�Ʈ��, �÷�� 1���� ��,
            for (int i = 0; i < 4; i++)
            {
                int r = Random.Range(0, rePositions.Count);
                if (i == 3)
                {
                    player.transform.position = rePositions[r].position;
                    player.transform.rotation = rePositions[r].rotation;
                }
                else
                {
                    testPlayers[i].SetActive(true);
                    testPlayers[i].transform.position = rePositions[r].position;
                    testPlayers[i].transform.rotation = rePositions[r].rotation;
                }
                rePositions.RemoveAt(r);
            }
            isReLocationed = !isReLocationed;
        }
    }
    void PlayS1Timeline()
    {
        playerMainCamera.cullingMask = 1;
        s1Timline.enabled = true;
    }
    #endregion
    #region S2Functions
    void Setting_S2()
    {
        s2Timline = s2.GetComponent<PlayableDirector>();
        s2Timline.enabled = false;

        rrobotAnim = Rrobot.GetComponent<Animator>();
    }
    void Play_S2()
    {
        s2Timline.enabled = true;
        Invoke("S1Off", 3);
        Invoke("RRobotAnimTrigger", 22);
    }
    void S1Off()
    {
        s1.SetActive(false);
    }
    void RRobotAnimTrigger()
    {
        rrobotAnim.SetTrigger("Start");

    }
    #endregion
}
