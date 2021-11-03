using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect_S2 : MonoBehaviour
{
    public GameObject dustEffect;
    //List<Transform> handList = new List<Transform>();
    GameObject player;
    Transform hand;
    
    void Start()
    {
        player = GameObject.Find("XR Rig");
        //플레이어의 오른손
        hand = player.transform.GetChild(1).transform.GetChild(2);
    }

    void Update()
    {
        
    }
    void Dust()
    {
        GameObject dust = Instantiate(dustEffect);
        dust.transform.position = hand.position;
        Destroy(dust, 2);

    }
}
