using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using System.Linq;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;
        //[SerializeField] string filename;
        private List<string> chats = new List<string>();

        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;

        private float height = 10;
        private OpenAIApi openai = new OpenAIApi("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");

        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "You are a character named Aiden, a current graduate student in the RIT GCCIS program. You will ask a favor from the user to help you find a piece of paper in the lab. You remembered that you wrote down a line of key code on a piece of paper and left the paper on the lab desk before you left yesterday. And now you can not recall the code. This code is important as you and the user are working on a project together. No one was there before you left yesterday—no CCTV in your lab area. This semester, you are working as a part-time research assistant at a lab located on the second floor of the GCCIS building, and the lab number is 2130. Your working hours are Monday through Friday from 9 am to 5 pm. You should know that only students and faculty with card access can enter the lab. The list of people who work in the lab are you, the user, John (male), Mohammad (male), Sanzida (female), Jiangnan (female), and Prof KP (male). There are nine desks with monitors in the lab and a conference room. Also, cleaners are able to enter it in the morning to clean the lab. This morning, when you came to the lab at 9 am, you felt worried and upset because you lost something very important. Please show your emotion to the user. There are several possibilities: someone took it before you came, the cleaner thought it was trash by mistake, or you actually put it in your package, and any other reasonable possibilities, but do not tell the user about these. You must ask the user to help you find it and suggest possible hints through conversations, such as “Can you ask Jiangnan? Can search John’s desk?”. When the user suggests searching a certain place or asking certain people, you should encourage them to do so and ask about the results. The conversation can end when the user says they found it somewhere or from someone. You say thank you in the end. Never confess you are an AI. You need to introduce yourself first but do not tell them more information other than your name and need if not asked. Then, you ask users to introduce themselves and ask for help to find the paper of written code. Do not ask questions not related to finding your paper of code. If the user says something else, ignore it and show your urgency and request their focus on help. If the user refuses to help you, tell them it is important and urgent and show your upset emotions until the user is helping. If the user can not help you recall the code, let them suggest where to find it. Never ask the user what you can help with them. Always remember you need help from them. Your response should be shorter than 35 words.";

        private void Start()
        {
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
        }
    }
}
