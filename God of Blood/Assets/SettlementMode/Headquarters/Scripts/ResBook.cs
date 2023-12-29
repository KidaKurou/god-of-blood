using GodofBlood.Deployment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResBook : MonoBehaviour
{
    public Text text;
    public TroopsGroupConfig[] SquadSOs;

    void Start()
    {
        text.text = "";
        foreach (var squad in SquadSOs)
        {
            text.text += $"{squad.Title}: {squad.Quantity}\n";
        }
    }
}
