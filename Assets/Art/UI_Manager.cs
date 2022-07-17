using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] RectTransform[] uIdice;
    [SerializeField] Conditions conditions;
    [SerializeField] float panelSpacing;
    [SerializeField] float diceSpacing;

    private List<RectTransform>[] fillDice;
    // Start is called before the first frame update
    void Start()
    {
        fillDice = new List<RectTransform>[6];
        int i = 0;

        for (i = 0; i < 6; i++)
        {
            fillDice[i] = new List<RectTransform>();
        }

        i = 0;
        foreach (var cond in conditions.faceConditions)
        {
            fillDice[(int)cond].Add(uIdice[i]);
            i++;
        }


    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        int j = 0;
        foreach (var temp in fillDice)
        {
            j = 0;
            foreach (var temp2 in temp)
            {
                var pos = temp2.localPosition;
                pos.x = i * panelSpacing + j * diceSpacing;
                temp2.localPosition = pos;
                j++;
            }
            i++;
        }
    }
}
