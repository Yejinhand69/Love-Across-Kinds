using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject AffectionPanel;
    public GameObject SettingButton;
    public GameObject AffectionButton;
    public GameObject EpisodesPhases;
    public GameObject MessageButton;
    public GameObject ObjectiveButton;
    public GameObject SettingPanel;
    public GameObject MessagePanel;
    public GameObject ObjectivePanel;
    public CameraRotateScript cameraRotateScript;

    public TextMeshProUGUI episodesText;
    public TextMeshProUGUI phasesText;

    private PhaseManager instance;

    public string phases;
    public int episode;

    private void Awake()
    {
        episodesText.text = string.Empty;
        phasesText.text = string.Empty;
    }

    private void Update()
    {
        if(SceneManager.sceneCount > 1 || DialogueManager.dialogueActive)
        {
            SettingButton.SetActive(false);
            AffectionButton.SetActive(false);
            EpisodesPhases.SetActive(false);
            MessageButton.SetActive(false);
            ObjectiveButton.SetActive(false);
            return;
        }
        else
        {
            SettingButton.SetActive(true);
            AffectionButton.SetActive(true);
            EpisodesPhases.SetActive(true);
            MessageButton.SetActive(true);
            ObjectiveButton.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Episode 0" || SceneManager.GetActiveScene().name == "Episode2")
        {
            SettingButton.SetActive(false);
            AffectionButton.SetActive(false);
            EpisodesPhases.SetActive(false);
            MessageButton.SetActive(false);
            ObjectiveButton.SetActive(false);

        }
        else
        {
            SettingButton.SetActive(true);
            AffectionButton.SetActive(true);
            EpisodesPhases.SetActive(true);
            MessageButton.SetActive(true);
            ObjectiveButton.SetActive(true);
        }

        episodesText.text = "EP: " + PhaseManager.instance.currentEpisode;
        phasesText.text = PhaseManager.instance.currentPhase;
    }



    public void OpenSettingPanel()
    {
        if (SettingPanel != null)
        {
            //bool isActive = Panel.activeSelf;//added
            //Panel.SetActive(!isActive);//added

            Animator animator = SettingPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openSettingPanel");

                animator.SetBool("openSettingPanel", !isOpen);
            }
        }
    }

    public void OpenAffectionWindow()
    {
        if (AffectionPanel != null)
        {
            Animator animator = AffectionPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openAffectionPanel");

                animator.SetBool("openAffectionPanel", !isOpen);
            }
        }
    }

    public void OpenObjectiveWindow()
    {
        if (ObjectivePanel != null)
        {
            Animator animator = ObjectivePanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openAffectionPanel");

                animator.SetBool("openAffectionPanel", !isOpen);
            }
        }
    }

    public void OpenMessagePanel()
    {
        if (MessagePanel != null)
        {
            Animator animator = MessagePanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("isOpenMessage");

                animator.SetBool("isOpenMessage", !isOpen);
            }
        }
    }
}
