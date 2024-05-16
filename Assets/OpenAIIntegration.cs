using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using OpenAI;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class OpenAIIntegration : MonoBehaviour
{
    private static string key="";
    private static string organization="";

    private OpenAIApi openAI;

    private List<ChatMessage> messages = new List<ChatMessage>();

    void Awake()
    {
        openAI = new OpenAIApi(key, organization);

        ChatMessage init = new ChatMessage();
        init.Content = "Your purpose is to generate provocative questions or actions for game Truth or Dare. You will be provided with category and type: truth or dare. Format should be following: 'Queston: text.' or 'Dare: text.' Language of your response will be specified";
        init.Role = "system";

        //Device ID will be sent in each user message so you won't send same guotes for same user more than once.

        messages.Add(init);
    }

    public void ClearCache()
    {
        PlayerPrefs.SetString("CURRENT_QUESTION", "none");
    }

    public async Task<string> Ask(string content, string language)
    {
        Debug.Log(content);
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        //Debug.Log("Device ID: " + deviceID);

        //content += "; DeviceID=" + deviceID;
        content += "; Response must be in language " + language;

        ChatMessage msg = new ChatMessage();
        msg.Content = content;
        msg.Role = "user";

        messages.Add(msg);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        //request.Model = "gpt-4o";
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);

        string messageResponse = "";

        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);

            messageResponse = chatResponse.Content;
        }

        return messageResponse;
    }

    public async Task<string> AskSimple(string content)
    {
        var category = content;
        int currentQuestionInCategory = PlayerPrefs.GetInt("QuestionIndexCategory"+category, 1);
        content = "Category: "+content+"; Question number "+currentQuestionInCategory.ToString();

        Debug.Log(content);
        string deviceID = SystemInfo.deviceUniqueIdentifier;

        ChatMessage msg = new ChatMessage();
        msg.Content = content;
        msg.Role = "user";

        messages.Add(msg);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";
        //request.Model = "gpt-4o";

        var response = await openAI.CreateChatCompletion(request);

        string messageResponse = "";

        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);

            messageResponse = chatResponse.Content;
        }

        PlayerPrefs.SetInt("QuestionIndexCategory"+category, currentQuestionInCategory + 1);

        return messageResponse;
    }
}
