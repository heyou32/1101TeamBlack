using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ArmTransformaion : MonoBehaviour
{
    [SerializeField] GameObject interacionCollider;
    Animator anim;
    [SerializeField] GameObject interactionGuide;
    [SerializeField]
    XRBaseController leftController;
    public float amplitue, duration;
    void Start()
    {
        leftController.SendHapticImpulse(amplitue, duration);
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == interacionCollider)
        {
            anim.SetTrigger("Triggered");
            interactionGuide.SetActive(false);
            StartCoroutine("Haptics");
            //콘트롤러에 진동
            Invoke("StopHaptics", duration);
        }
    }
    IEnumerator Haptics()
    {
        while (true)
        {
            leftController.SendHapticImpulse(amplitue, duration);
            yield return null;
        }
    }
    void StopHaptics()
    {
        StopCoroutine("Haptics");

    }
}
