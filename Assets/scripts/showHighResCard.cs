using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PokemonTcgSdk.Models;
using UnityEngine.UI;
using UnityEngine.Networking;

public class showHighResCard : MonoBehaviour
{
    [SerializeField] Image image;

    public void showimage(PokemonCard info)
    {
        StartCoroutine(GetRequest(info.ImageUrlHiRes));
    }

    public void hideimage()
    {
        image.sprite = null;
    }
    IEnumerator GetRequest(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogWarning(request.error);
            yield break;
        }

        var texture = DownloadHandlerTexture.GetContent(request);
        var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.one * 0.5f);
        image.sprite = sprite;
    }
}
