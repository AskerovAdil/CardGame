using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardModel : MonoBehaviour
{

    [SerializeField]
    private Sprite FaceSprite,BackSprite;
    [SerializeField]
    private Image ImagePhoto, ImageForSprite;

    // Start is called before the first frame update
    void Start()
    {
        ImageForSprite.sprite = BackSprite;
    }

    public void UploadCard(bool FlipCard = true)
    {
        StartCoroutine(GetImageFromWeb("https://picsum.photos/200/300", FlipCard));

    }

    public IEnumerator FlipCard()
    {
        var anim = gameObject.GetComponent<Animation>();
        anim.Play();
        yield return new WaitForSeconds(anim.clip.length);

        ImageForSprite.sprite = FaceSprite;
    }

    public IEnumerator CancelCard()
    {
        var anim = gameObject.GetComponent<Animation>();
        anim.Play();
        yield return new WaitForSeconds(anim.clip.length);

        ImageForSprite.sprite = BackSprite;

        StopAllCoroutines();
    }


   
     IEnumerator GetImageFromWeb(string url, bool FlipCart = true)
    {
        var request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            Texture2D image = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(image, new Rect(0, 0, 200, 300), Vector2.zero);
            ImagePhoto.sprite = sprite;

            if(FlipCart) StartCoroutine(FlipCard());
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
        }

        request.Dispose();
    }

}
