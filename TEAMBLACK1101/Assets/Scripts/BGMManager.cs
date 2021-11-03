using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    //AudioSource bgm;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //bgm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
