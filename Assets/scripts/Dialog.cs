using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private string speaker, dialog;

    public Dialog(string speaker, string dialog)
    {
        this.speaker = speaker;
        this.dialog = dialog;
    }

    public string GetSpeaker()
    {
        return speaker;
    }

    public string GetDialog()
    {
        return dialog;
    }
}
