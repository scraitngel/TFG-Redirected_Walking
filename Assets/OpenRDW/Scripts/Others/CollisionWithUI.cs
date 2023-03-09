using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit;

public class CollosionWithUI : MonoBehaviour
{
    void Start()
    {
        // . . .
        // Start logging information
        //StartCoroutine(LogInformation());
        // . . .
    }

    int log = 0;

    IEnumerator LogInformation()
    {

        // Select file to log information
        var fileName = Path.Combine(Application.persistentDataPath, "mi_fichero.txt");  // Can be replaced to a non-persistent directory in PC

        // Infinite loop
        var currentTime = Time.deltaTime;
        while (true)
        {
            var line = "";
            if (log != 0)
            {
                switch (log)
                {
                    case 1:
                        line = "Enter";
                        break;
                    case 2:
                        line = "Stay";
                        break;
                }

                log = 0;
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(line);
                }
            }
            // Define frequency of update
            yield return new WaitForSeconds(0.05f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        log = 1;
    }

    void OnCollisionStay(Collision collision)
    {
        log = 2;
        if (Input.anyKey)
        {
            transform.GetComponent<Button>().onClick.Invoke();
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.GetComponent<Button>().onClick.Invoke();
    }
}
