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

    [Header("")]
   public NowScene nowScene;
    public enum NowScene
    {
        S1,S2,S3
    }

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

        switch (nowScene)
        {
            case NowScene.S1:
                break;
            case NowScene.S2:
                break;
            case NowScene.S3:
                RestarOrQuit();
                break;
        }
    }

    void SelectScene()
    {
        //������ Ʈ���� ���� Scene Selct UI ���� �״�
        if (rightHand.triggered)
        {
            isActive = !isActive;
        }

        if (isActive)
        {
            sceneMenu.SetActive(true);

            //�޼� Ʈ���ŷ� �� ����
            if (leftHand.triggered)
            {
                if (leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) && scenes.Contains(hit.transform))
                {
                    print($"{hit.transform.gameObject.name}�� �̵�");
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
        //�޼� Ʈ���ŷ� �����ϸ� �����̼� ���
        if (leftHand.triggered)
        {
            if (leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) && hit.transform == audioUI)
            {
                narration.Play();
                rrobot.SetTrigger("Narration");
            }
        }
    }

    [Header("Only use in S3")]
    public GameObject restratButton, exitButton;
    void RestarOrQuit()
    {
        //S3 ���ͷ��ǰ� ���ϸ��̼� ������ Ȱ��ȭ��
        if (leftHand.triggered&& leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.transform.gameObject == restratButton)
            {
                SceneManager.LoadScene(0);
            }
            if(hit.transform.gameObject== exitButton)
            {
                Application.Quit();
            }
        }
    }
}
