using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private GameObject CardPrefab;

    [SerializeField]
    private int CountCard;

    public static List<CardModel> cards = new List<CardModel>();

    //Это можно получить из Unity перетащив соответствующий скрипт
    public static List<IOptionsLoader> options = new List<IOptionsLoader>();

    [SerializeField]
    private TMP_Dropdown selectOptions;

    public void Start()
    {
        GenerateOptionsLoader();
        //Загрузка Options в Dropdown
        GenerateCards();
    }

    private void GenerateOptionsLoader()
    {
        options.Add(new LoadOneByOne("Load One By One"));
        options.Add(new LoadAllAtOnce("All at once"));
        options.Add(new LoadWhenImageReady("When Image Ready"));

        AddOptionsDropdown();
    }

    private void AddOptionsDropdown()
    {
        options.ForEach(option =>
        {
            selectOptions.options.Add(new TMP_Dropdown.OptionData(option.Name));
        });
    }

    private void GenerateCards()
    {
        var widthWindow = Screen.width;
        var widthOnCard = widthWindow / (CountCard + 1);

        var Step = -widthWindow / 2;
        for (int i = 0; i < CountCard; i++)
        {
            Step += widthOnCard;

            GameObject newCard = Instantiate(CardPrefab, new Vector2(Step, 0), Quaternion.identity);
            GameObject parent = GameObject.FindGameObjectWithTag("Cards");

            newCard.transform.SetParent(parent.transform, false);

            cards.Add(newCard.GetComponent<CardModel>());
        }
    }


}
