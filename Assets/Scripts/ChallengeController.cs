using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeController : MonoBehaviour
{

    [SerializeField] Text infoText;
    [SerializeField] InputField field;
    int number;


    void Start()
    {
        number = Random.Range(0, 101);
    }

    public void Press()
    {
        if (number > int.Parse(field.text))
        {
            infoText.text = "Загаданное число больше";
        }
        else if (number < int.Parse(field.text))
        {
            infoText.text = "Загаданное число меньше";
        }
        else
        {
            infoText.text = "Число угадано!";
        }
    }
}
