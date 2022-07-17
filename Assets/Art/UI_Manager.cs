using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] RectTransform[] uiDice;
    [SerializeField] SpriteRenderer[] lockedSprites;
    [SerializeField] SpriteRenderer[] brightSprites;
    [SerializeField] CC cc;

    [SerializeField] Conditions conditions;
    [SerializeField] float panelSpacing;
    [SerializeField] float diceSpacing;
    [SerializeField] float fadeSpeed = 2;
    [SerializeField] TextMeshProUGUI movesText;
    [SerializeField] TextMeshProUGUI[] infoTexts;

    private List<RectTransform>[] fillDice;
    private float[] glowOpacity;
    private FadeToggle floatyTile;

    void Start()
    {
        fillDice = new List<RectTransform>[6];
        int i = 0;
        glowOpacity = new float[6];
        floatyTile = FindObjectOfType<FadeToggle>();

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
        glowOpacity[0] += Time.deltaTime * fadeSpeed * ConditionToSign(cc.hasWon);

        if (cc.doingNothing)
            glowOpacity[1] = 1;
        else
            glowOpacity[1] -= Time.deltaTime * fadeSpeed;

        if (cc.rotate90)
            glowOpacity[2] = 1;
        else
            glowOpacity[2] -= Time.deltaTime * fadeSpeed;

        if (cc.canTeleport)
            glowOpacity[3] = 1;
        else
            glowOpacity[3] -= Time.deltaTime * fadeSpeed;

        if (floatyTile != null)
            glowOpacity[4] = floatyTile.opacity;

        glowOpacity[5] += Time.deltaTime * fadeSpeed * ConditionToSign(cc.alternateMovement);

        //set all opacities
        for (int i = 0; i < 6; i++)
        {
            glowOpacity[i] = Mathf.Clamp(glowOpacity[i], 0, 1);
            brightSprites[i].color = new Color(1, 1, 1, glowOpacity[i]);
        }

        //setMoves
        movesText.text = "Moves: " + cc.moveCounter;

        //info
        if ((Input.GetKeyDown(KeyCode.I)))
        {
            foreach (var infoText in infoTexts)
            {
                infoText.enabled = true;
            }
        }
        else if ((Input.GetKeyUp(KeyCode.I)))
        {
            foreach (var infoText in infoTexts)
            {
                infoText.enabled = false;
            }
        }
    }

    int ConditionToSign(bool condition)
    {
        return Convert.ToInt32(condition) * 2 - 1;
    }
}
