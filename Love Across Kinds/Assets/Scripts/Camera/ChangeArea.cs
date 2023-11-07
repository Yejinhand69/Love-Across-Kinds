using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject LobbyDoorPanel;
    public GameObject DiningRoomDoorPanel;
    public GameObject PoolDoorPanel;
    public GameObject RecordingDoorPanel;
    public GameObject ArcadeDoorPanel;

    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private float pressDuration;

    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        TryGetComponent<DialogueTrigger>(out dialogueTrigger);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isSwiping)
        {
            pressTime = Time.time;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isSwiping)
        {
            float releaseTime = Time.time;
            pressDuration = releaseTime - pressTime;
            if (pressDuration <= swipeThreshold)
            {
                // Check if the object you clicked/touched has the "phase changer" tag
                if (gameObject.CompareTag("LobbyDoor"))
                {
                    OpenLobbyDoorPanel();
                    //Camera.main.transform.position = new Vector3(0.0f, 0.5f, -7.06f);
                }
                if (gameObject.CompareTag("DiningRoomDoor"))
                {
                    OpenDiningDoorPanel();
                    //Camera.main.transform.position = new Vector3(6.08f, 0.5f, -14.23f);
                }
                if (gameObject.CompareTag("PoolDoor"))
                {
                    OpenPoolDoorPanel();
                    //Camera.main.transform.position = new Vector3(15.668f, 0.5f, 14.95f);
                }
                if (gameObject.CompareTag("ArcadeDoor"))
                {
                    OpenArcadeDoorPanel();
                    //Camera.main.transform.position = new Vector3(15.668f, 0.5f, 14.95f);
                }
                if (gameObject.CompareTag("RecordingDoor"))
                {
                    OpenRecordingDoorPanel();
                    //Camera.main.transform.position = new Vector3(15.668f, 0.5f, 14.95f);
                }
                if (gameObject.CompareTag("Bedroom"))
                {
                    if(PhaseManager.instance.currentPhase == "FreeTime" || PhaseManager.instance.currentPhase == "Prologue")
                    {
                        if (DialogueManager.instance.XinaAttemp > 0 && DialogueManager.instance.BeniaAttemp > 0) //&&DialogueManager.instance.FlorineAttemp > 0)
                        {
                            dialogueTrigger.StartDialogue(" ", 282);
                        }
                        else
                        {
                            dialogueTrigger.StartDialogue(" ", 280);
                        }
                    }                
                }
            }

        }
    }

    public void OpenLobbyDoorPanel()
    {
        if (LobbyDoorPanel != null)
        {
            Animator animator = LobbyDoorPanel.GetComponent<Animator>();
            if (animator != null)
            {
               
                bool isOpen = animator.GetBool("openLobbyDoorPanel");

                animator.SetBool("openLobbyDoorPanel", !isOpen);
            }

        }
    }

    public void TransportToLobby()
    {
        Camera.main.transform.position = new Vector3(0.0f, 0.5f, -7.06f);
    }

    public void OpenDiningDoorPanel()
    {
        if (DiningRoomDoorPanel != null)
        {
            Animator animator = DiningRoomDoorPanel.GetComponent<Animator>();
            if (animator != null)
            {

                bool isOpen = animator.GetBool("openDiningDoorPanel");

                animator.SetBool("openDiningDoorPanel", !isOpen);
            }

        }
    }

    public void TransportToDining()
    {
        Camera.main.transform.position = new Vector3(0.0f, 4.3f, -7.06f);
    }

    public void OpenPoolDoorPanel()
    {
        if (PoolDoorPanel != null)
        {
            Animator animator = PoolDoorPanel.GetComponent<Animator>();
            if (animator != null)
            {

                bool isOpen = animator.GetBool("openPoolDoorPanel");

                animator.SetBool("openPoolDoorPanel", !isOpen);
            }

        }
    }

    public void TransportToPool()
    {
        Camera.main.transform.position = new Vector3(0.0f, 8.9f, -7.06f);
    }
    public void OpenArcadeDoorPanel()
    {
        if (ArcadeDoorPanel != null)
        {
            Animator animator = ArcadeDoorPanel.GetComponent<Animator>();
            if (animator != null)
            {

                bool isOpen = animator.GetBool("openArcadeDoorPanel");

                animator.SetBool("openArcadeDoorPanel", !isOpen);
            }

        }
    }

    public void TransportToArcade()
    {
        Camera.main.transform.position = new Vector3(0.0f, 13.42f, -7.06f);
    }

    public void OpenRecordingDoorPanel()
    {
        if (RecordingDoorPanel != null)
        {
            Animator animator = RecordingDoorPanel.GetComponent<Animator>();
            if (animator != null)
            {

                bool isOpen = animator.GetBool("openRecordingDoorPanel");

                animator.SetBool("openRecordingDoorPanel", !isOpen);
            }

        }
    }

    public void TransportToRecording()
    {
        Camera.main.transform.position = new Vector3(0.0f, -4.03f, -10f);
    }

}
