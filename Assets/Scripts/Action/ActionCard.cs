using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ActionCard : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown selectOptions;


    public void LoadCards()
    {
        var action = LoadScene.options[selectOptions.value].LoadingCards(this);
        StartCoroutine(action);
    }

    public void CloseCards()
    {
        foreach (var el in LoadScene.cards)
        {
            StartCoroutine(el.CancelCard());
        }
    }

}
