using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun; // Only needed if you're using Photon

public class WebhookNotifier : MonoBehaviour
{
    private string webhookUrl = "https://discord.com/api/webhooks/1388697114040864808/5-qs46ykEpfmUstD3ejvdxVzcx9EoBrG_JM_kejWDNNcI_ps-7goe81d66W1hgtI_P0A";

    void Start()
    {
        // Example trigger
        StartCoroutine(SendDiscordWebhook($"**{PhotonNetwork.LocalPlayer.NickName}** has loaded into the game with **Inject**!"));
    }

    private IEnumerator SendDiscordWebhook(string message)
    {
        WWWForm form = new WWWForm();
        form.AddField("content", message);

        using (UnityWebRequest www = UnityWebRequest.Post(webhookUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.LogError("Webhook error: " + www.error);
            else
                Debug.Log("Webhook sent successfully.");
        }
    }
}
