using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBoard : MonoBehaviour
{

    [SerializeField] GameObject leftHand, rightHand;
    [SerializeField] GameObject rrbot;
    Animator rrobotAnim;
    AudioSource rrobotAudio;
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

    int r;

    void Awake()
    {
        countdownObj.SetActive(false);
        rrobotAnim = rrbot.GetComponent<Animator>();
        rrobotAudio = rrbot.GetComponent<AudioSource>();

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
        if (other.gameObject == leftHand || other.gameObject == rightHand)
        {
            InteractionClear();
        }
    }
    void InteractionClear()
    {
        rrobotAnim.Play("Clapping");
        rrobotAudio.Play();

        // Invoke("EndingMent", 6);
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
    void EndingMent()
    {

    }
}
