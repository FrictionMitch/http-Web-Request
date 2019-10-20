using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DownLoadImage : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;

    [SerializeField]
    string _url = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/19/Unity_Technologies_logo.svg/1280px-Unity_Technologies_logo.svg.png";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DownloadRoutine());

        }
    }

    IEnumerator DownloadRoutine()
    {
        UnityWebRequest download = UnityWebRequestTexture.GetTexture(_url);
        
            yield return download.SendWebRequest();

            if (download.isNetworkError)
            {
                Debug.Log("Download failed");
            }
            else
            {
                // successful
                _rawImage.texture = ((DownloadHandlerTexture)download.downloadHandler).texture;
            }
        
    }
}
