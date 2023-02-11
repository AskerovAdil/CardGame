using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOneByOne : IOptionsLoader
{
    public LoadOneByOne(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public IEnumerator LoadingCards(MonoBehaviour instance)
    {
        foreach (var el in LoadScene.cards)
        {
            el.UploadCard();
            yield return new WaitForSeconds(0.6f);
        }
    }
}
