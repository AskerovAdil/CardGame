using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAllAtOnce : IOptionsLoader
{
    public LoadAllAtOnce(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public IEnumerator LoadingCards(MonoBehaviour instance)
    {
        foreach (var el in LoadScene.cards)
        {
            el.UploadCard(false);
            instance.StartCoroutine(el.FlipCard());
        }
        yield return null;
    }
}
