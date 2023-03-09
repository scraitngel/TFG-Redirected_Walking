using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choices : MonoBehaviour
{
    public Text textBox;
    public static string redirector = "";
    public static string resetter = "";
    public static string momentum = "";

    public void chooseRedirector (string option) {
        redirector = option;
    }

    public void chooseResetter (string option) {
        resetter = option;
    }

    public void chooseMoment (string option) {
        momentum = momentum + (momentum == "" ? option : " " + option);
        if (textBox != null) textBox.text = momentum;
    }

    public void resetMomentChoices() {
        Choices.momentum = "";
    }
    
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
