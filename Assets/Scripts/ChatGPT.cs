using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using System.Linq;
using UnityEngine.SceneManagement;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        /*[SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;
        //[SerializeField] string filename;
        private List<string> chats = new List<string>();

        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;

        private float height = 10;
        private OpenAIApi openai = new OpenAIApi();

        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt;

        private void Start()
        {
            Scene scenename = SceneManager.GetActiveScene();
            if (scenename.name == "Puzzle1")
            {
                prompt = "Your name is Qubit, now you help the user to decode a Morse code from audio. You can tell them the audio is Morse code, introduce Morse code, and how numbers and the alphabet are translated into dashes and dots. However, you should not tell them what the Morse code represents when they show you a string of dashes and dots, you should guide them to decode by themselves. If they talk about things other than decoding the audio, you should let them focus and show the urgency of the task.";
            }
            else if (scenename.name == "Puzzle2")
            {
                prompt = "Your name is Qubit. Now, you help the user to understand how to solve a color puzzle. If asked about the color cubes, you can tell the user to find color stickers on the first floor of Magic Spell Studio. If they ask about the numbers, tell them that the numbers on the color stickers represent the order of the color cube.";
            }
            button.onClick.AddListener(SendReply);
        }

        private void AppendMessage(ChatMessage message)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

            var item = Instantiate(message.Role == "user" ? sent : received, scroll.content);
            item.GetChild(0).GetChild(0).GetComponent<Text>().fontSize = 60;
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = message.Content;

            if (item.name == "Sent Message(Clone)")
            {
                item.GetComponent<RectTransform>().offsetMin = new Vector2(300, 10);// 300, 50 to -50, 300
                item.GetComponent<RectTransform>().offsetMax = new Vector2(50, -height);
            }
            else if (item.name == "Received Message(Clone)")
            {
                item.GetComponent<RectTransform>().offsetMin = new Vector2(-50, 10);
                item.GetComponent<RectTransform>().offsetMax = new Vector2(-300, -height);
            }
            //item.anchoredPosition = new Vector2(200, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        private async void SendReply()
        {
            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = inputField.text
            };

            AppendMessage(newMessage);
            Debug.Log("chat user : " + newMessage.Content);
            if (messages.Count == 0)
            {
                newMessage.Content = prompt + "\n" + inputField.text;
            }
            messages.Add(newMessage);
            chats.Add(newMessage.Content);
            button.enabled = false;
            inputField.text = "";
            inputField.enabled = false;

            // Complete the instruction
            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = messages
            });
            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();

                messages.Add(message);
                chats.Add(message.Content);
                AppendMessage(message);
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }
            //FileHandler.SaveToJSON<string>(chats, filename);
            button.enabled = true;
            inputField.enabled = true;
        }*/
    }
}
