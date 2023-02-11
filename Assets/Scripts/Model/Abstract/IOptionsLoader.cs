using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOptionsLoader 
{


    string Name { get; set; }
    IEnumerator LoadingCards(MonoBehaviour instance);
}
