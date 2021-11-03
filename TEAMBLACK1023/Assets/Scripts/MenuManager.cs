using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputActionAsset xriInputAction;
    [SerializeField] XRRayInteractor leftRayInteractor;
    InputAction rightHand;
    InputAction leftHand;
    [Header("")]
    public GameObject sceneMenu;
    [SerializeField] Transform rightHandPosition;
    [SerializeField] List<Transform> scenes = new List<Transform>();
    [Header("")]
    [SerializeField] Transform audioUI;
    AudioSource narration;
    [SerializeField] Animator rrobot;
    void Start()
    {
        rightHand = xriInputAction.FindActionMap("XRI RightHand").FindAction("UI Press");
        leftHand = xriInputAction.FindActionMap("XRI LeftHand").FindAction("UI Press");
        //rightThumbStick.Enabled();
        sceneMenu.SetActive(false);

        narration = audioUI.gameObject.GetComponent<AudioSource>();
    }
    bool isActive;
    void Update()
    {
        SelectScene();

        PlayNarration();


    }

    void SelectScene()
    {
        //오른손 트리거 당기면 Scene Selct UI 껐다 켰다
        if (rightHand.triggered)
        {
            isActive = !isActive;
        }

        if (isActive)
        {
            sceneMenu.SetActive(true);

            //왼손 트리거로 씬 선택
            if (leftHand.triggered)
            {
                if (leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) && scenes.Contains(hit.transform))
                {
                    print($"{hit.transform.gameObject.name}로 이동");
                    SceneManager.LoadScene(hit.transform.gameObject.name);
                }
            }
        }
        else
            sceneMenu.SetActive(false);

        sceneMenu.transform.position = rightHandPosition.position;
    }

    void PlayNarration()
    {
        if (leftHand.triggered)
        {
            if (leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) && hit.transform == audioUI)
            {
                narration.Play();
                rrobot.SetTrigger("Narration");
            }
        }
    }
    public void S1Select()
    {
        print(55);
    }
}
