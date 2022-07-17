using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] RectTransform[] uiDice;
    [SerializeField] SpriteRenderer[] lockedSprites;
    [SerializeField] SpriteRenderer[] brightSprites;
    [SerializeField] CC cc;

    [SerializeField] Conditions conditions;
    [SerializeField] float panelSpacing;
    [SerializeField] float diceSpacing;

    private List<RectTransform>[] fillDice;
    private float[] glowOpacity;

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
            fillDice[(int)cond].Add(uiDice[i]);
            i++;
        }

        i = 0;
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

            if (j == 0)
            {
                lockedSprites[i].color = new Color(1, 1, 1, 1);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.rotate90)
        {
            //WIP
        }
    }
}
