using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class CSVDownloader
{
    private const string googleSheetID = "1YZLcQViYt0P8RspIK8cWCLKDEK5QyE6lBFf7eqDx-ao";
    private const string url = "https://docs.google.com/spreadsheets/d/" + googleSheetID + "/export?format=csv";

    internal static IEnumerator DownloadData(System.Action<string> onCompleted)
    {
        yield return new WaitForEndOfFrame();

        string downloadData = null;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Download Error: " + webRequest.error);
                downloadData = PlayerPrefs.GetString("LastDataDownloaded", null);
            }
            else
            {
                Debug.Log("Download success");
                Debug.Log("Data: " + webRequest.downloadHandler.text);

                PlayerPrefs.SetString("LastDataDownloaded", webRequest.downloadHandler.text);

                downloadData = webRequest.downloadHandler.text;
            }
        }

        onCompleted(downloadData);
    }
}
