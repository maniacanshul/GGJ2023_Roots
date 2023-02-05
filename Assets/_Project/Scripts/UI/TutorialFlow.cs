using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFlow : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialPanels;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject playButton;

    private int tutorialCounter;

    private void Start()
    {
        ShowTutorial();
    }

    public void ShowTutorial()
    {
        tutorialCounter = 0;
        previousButton.SetActive(false);
        nextButton.SetActive(true);
        playButton.SetActive(false);
        UpdateTutorialPage();
    }

    public void PreviousButtonCallback()
    {
        tutorialCounter--;
        if (tutorialCounter <= 0)
        {
            tutorialCounter = 0;
            previousButton.SetActive(false);
        }
        playButton.SetActive(false);
        nextButton.SetActive(true);
        UpdateTutorialPage();
    }

    public void NextButtonCallback()
    {
        tutorialCounter++;
        if (tutorialCounter >= tutorialPanels.Length - 1)
        {
            tutorialCounter = tutorialPanels.Length - 1;
            nextButton.SetActive(false);
            playButton.SetActive(true);
        }
        previousButton.SetActive(true);
        UpdateTutorialPage();
    }

    private void UpdateTutorialPage()
    {
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            tutorialPanels[i].SetActive(i == tutorialCounter);
        }
    }
}
