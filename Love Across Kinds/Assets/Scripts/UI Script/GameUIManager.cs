using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public GameObject Phase_Episode;
    private Image image;
    private Animator anim;
    private TextMeshProUGUI PhaseEpisodeText;

    private void Awake()
    {
        image = Phase_Episode.GetComponent<Image>();
        anim = Phase_Episode.GetComponent<Animator>();
        PhaseEpisodeText = Phase_Episode.GetComponentInChildren<TextMeshProUGUI>();

        PhaseEpisodeText.text = "Episode " + PhaseManager.instance.currentEpisode + "\n" + PhaseManager.instance.currentPhase;

        if (DialogueManager.instance.phaseIndicator != PhaseManager.instance.currentPhase)
        {
            anim.SetBool("", false);

            anim.SetBool("", true);
        }
    }
}
