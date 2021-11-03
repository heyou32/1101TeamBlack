using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBoard : MonoBehaviour
{

    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rrbot;
    Animator rrobotAnim;
    [Header("")]

    [SerializeField] GameObject curcuitBoard;
    Animation mainpartAnim;
    AudioSource mainpartSFX;


    [SerializeField] GameObject[] subParts;
    Animation subpartAnim;
    [Header("")]

    [SerializeField] GameObject doors;
    Animation doorAnim;
    AudioSource doorSFX;

    [SerializeField] GameObject countdownObj;

    public int r;

    void Awake()
    {
        countdownObj.SetActive(false);
        rrobotAnim = rrbot.GetComponent<Animator>();

        r = UnityEngine.Random.Range(0, subParts.Length);
        transform.position = subParts[r].transform.position;
        subpartAnim = subParts[r].GetComponent<Animation>();
        subpartAnim.enabled = true;

        mainpartAnim = curcuitBoard.GetComponent<Animation>();
        mainpartSFX = curcuitBoard.GetComponent<AudioSource>();
        //subParts[r].GetComponent<BoxCollider>().enabled = true;

        doorAnim = doors.GetComponent<Animation>();
        doorSFX = doors.GetComponent<AudioSource>();
    }
    public bool check;
    private void Update()
    {
        if (check)
        {
            InteractionClear();
            check = !check;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftHand)
        {
            InteractionClear();
        }
    }
    void InteractionClear()
    {
        rrobotAnim.Play("Clapping");
        mainpartSFX.Play();
        mainpartAnim.enabled = true;
        subpartAnim.enabled = false;
        Invoke("DoorOpen", 2f);
    }
    void DoorOpen()
    {
        doorSFX.Play();
        doorAnim.enabled = true;
        countdownObj.SetActive(true);
    }
}
