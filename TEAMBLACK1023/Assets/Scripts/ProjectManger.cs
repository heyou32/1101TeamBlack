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
        //S1의 타임라인을 가져옴
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

        //플레이어 위치 재배치하고
        PlayersReLocation();
        //S1 에니메이션 시작
        Invoke("PlayS1Timeline", 1);
    }
    void PlayersReLocation()
    {
        //메인 플레이어가 아바타 선택 후, 선택하지 않은 나머지들을 더미로 쓰기 위해 리스트화 해야함.

        if (!isReLocationed)
        {
            //카메라 흐려지는 효과.  //수정해야할듯
            playerMainCamera.cullingMask = 0;



            //플레이어 위치 랜덤으로 재배치

            //for (int i = 0; i < playerList.Count; i++)
            //{
            //    playerList[i].transform.position=rePositions[r].position;
            //playerList[i].transform.rotation = rePositions[r].rotation;

            //    rePositions.RemoveAt(r);
            //}

            //테스트용, 플레어가 1인일 때,
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
