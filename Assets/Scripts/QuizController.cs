using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    int counter;
    int step;

    bool hintIsShown;

    [SerializeField] List<GameObject> quizPanels;
    List<GameObject> selectedQuizPanels;

    [SerializeField] GameObject introPanel;
    [SerializeField] GameObject hintPanel;
    [SerializeField] GameObject winPanel;
    GameObject currentActivePanel;

    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] TMP_InputField field;

    void Start()
    {
        counter = 0;
        step = 0;
        currentActivePanel = introPanel;
        currentActivePanel.SetActive(true);
        selectedQuizPanels = new List<GameObject>();
        selectedQuizPanels.AddRange(quizPanels);
    }

    public void WrongPress()
    {
        ShowNext();
    }

    public void CorrectPress()
    {
        counter++;
        ShowNext();
    }

    public void CheckField(string correctString)
    {
        field = FindObjectOfType<TMP_InputField>();

        if (correctString == field.text)
        {
            CorrectPress();
        }
        else
        {
            WrongPress();
        }
    }

    public void ShowHint()
    {
        if (!hintIsShown)
        {
            hintPanel.SetActive(true);
            hintIsShown = true;
        }
    }

    void ShowNext()
    {
        if (currentActivePanel != null)
        {
            currentActivePanel.SetActive(false);

            if (step < 10)
            {
                int rand = Random.Range(0, selectedQuizPanels.Count);
                currentActivePanel = selectedQuizPanels[rand];
                currentActivePanel.SetActive(true);
                selectedQuizPanels.Remove(selectedQuizPanels[rand]);
                step++;
            }
            else
            {
                winPanel.SetActive(true);
                counterText.text = counter + "/10";
            }
        }
    }

    public void PressExit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
