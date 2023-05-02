using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using TMPro;

[System.Serializable]
public class MagicCardInput
{
    public string name;
    public string mana_cost;
    public string oracle_text;
    public string type;
    public string powertough;
}

[System.Serializable]
public class ChatGPTResponse
{
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public string text;
}

public class ChatGPT : MonoBehaviour
{
    public string ApiKey = "your-key-here";
    private const string ApiEndpoint = "https://api.openai.com/v1/engines/text-davinci-002/completions";

    public string userInput;

    public string name;
    public string mana_cost;
    public string oracle_text;
    public string type;
    public string powertough;

    public TextMeshProUGUI inputMechanic;

    private void Start()
    {
        // NewInput();
    }

    public void NewInput(){
        StartCoroutine(SendMessageToChatGPT());
    }

    private IEnumerator SendMessageToChatGPT()
    {
        MagicCardInput inputMessage = new MagicCardInput();
        string message = "I am creating an AI generated magic the gathering set for a few friends to draft during the summer. The goal is to create fun cards that have cool interactions, but have low mana cost and mechanics and keywords from magics past. Generate one new Magic the gathering card in a JSON string. Do not add any extra commentary. The type line should use the long dash. The mana cost should have curly brackets between each symbol. The oracle text should be under 100 words. "+ inputMechanic.text +". This should be the format of the JSON string:"  + JsonUtility.ToJson(inputMessage, true);

        string encodedMessage = message.Replace("\n", "\\n").Replace("\"", "\\\"");
        string jsonRequestBody = "{\"prompt\": \"" + encodedMessage + "\", \"max_tokens\": 200, \"temperature\": 1.0}";

        using (UnityWebRequest webRequest = new UnityWebRequest(ApiEndpoint, "POST"))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", "Bearer " + ApiKey);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequestBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string response = webRequest.downloadHandler.text;
                PrintChatGPTResponse(response);
            }
            else
            {
                Debug.Log("Error: " + webRequest.error);
            }
        }
    }


    private void PrintChatGPTResponse(string response)
    {
        ChatGPTResponse chatGPTResponse = JsonUtility.FromJson<ChatGPTResponse>(response);
        string message = chatGPTResponse.choices[0].text.Trim();
        Debug.Log("ChatGPT Response: " + message);

        MagicCardInput magicCard = JsonUtility.FromJson<MagicCardInput>(message);

        name = magicCard.name;
        mana_cost = magicCard.mana_cost;
        oracle_text = magicCard.oracle_text;
        type = magicCard.type;
        powertough = magicCard.powertough;
    }
}
