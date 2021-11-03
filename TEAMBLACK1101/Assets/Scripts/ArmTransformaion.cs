using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ArmTransformaion : MonoBehaviour
{
    [SerializeField] GameObject interacionCollider;
    Animator anim;
    [SerializeField] GameObject uiHand;
    [SerializeField]
    XRBaseController leftController;
    public float amplitue, duration;
    
    void Start()
    {
        leftController.SendHapticImpulse(amplitue, amplitue);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        leftController.SendHapticImpulse(amplitue, amplitue);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == interacionCollider)
        {
            anim.SetTrigger("Triggered");
            uiHand.SetActive(false);
        }
    }
    void HapticLeftHand()
    {
        //HARWrapper 
    }
}
