using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWhenImageReady : IOptionsLoader
{
    public LoadWhenImageReady(string name)
    {
        Name = name;
    }
    public string Name { get ; set ; }

    public IEnumerator LoadingCards(MonoBehaviour instance)
    {
        foreach (var el in LoadScene.cards)
        {
            el.UploadCard();
        }
        yield return null;
    }


    
}
