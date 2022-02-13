using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

using Anchor.Model;
using System.Windows.Media;

namespace Anchor.Managers
{
    internal class SerializationManager
    {
        static public void SaveDialogueProgression(string filePath, DialogueProgression progression)
        {
            XmlWriter writer = new XmlTextWriter(filePath, Encoding.UTF8);

            writer.WriteStartDocument();
            writer.WriteWhitespace("\n");

            writer.WriteStartElement("Game");
            writer.WriteWhitespace("\n");

            foreach (DialogueScene scene in progression.Scenes)
            {
                switch (scene.Type)
                {
                    case DialogueSceneType.Conversation:
                        writer.WriteStartElement("Conversation");
                        writer.WriteString(scene.Content);
                        writer.WriteEndElement();
                        break;
                    case DialogueSceneType.Title:
                        writer.WriteStartElement("TitleScreen");
                        writer.WriteAttributeString("Duration", ((TitleScene)scene).Duration.ToString());
                        writer.WriteAttributeString("r", ((TitleScene)scene).Red.ToString());
                        writer.WriteAttributeString("g", ((TitleScene)scene).Green.ToString());
                        writer.WriteAttributeString("b", ((TitleScene)scene).Blue.ToString());
                        writer.WriteString(scene.Content);
                        writer.WriteEndElement();
                        break;
                    case DialogueSceneType.PillState:
                        writer.WriteStartElement("PillSequence");
                        writer.WriteAttributeString("NumPills", ((PillScene)scene).NumPills.ToString());
                        writer.WriteEndElement();
                        break;
                    case DialogueSceneType.DrawingState:
                        writer.WriteStartElement("DrawingState");
                        writer.WriteAttributeString("FilePath", ((DrawingScene)scene).DrawingFilePath);
                        writer.WriteEndElement();
                        break;
                }
                writer.WriteWhitespace("\n");
            }

            writer.WriteEndElement();

            writer.WriteEndDocument();

            writer.Close();
        }

        static public DialogueProgression LoadProgression(string filePath)
        {
            DialogueProgression result = new DialogueProgression();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            string baseFilePath = filePath.Substring(0, filePath.LastIndexOf('\\')+1);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                DialogueScene currentScene;
                switch (node.Name)
                {
                    case "Conversation":
                        currentScene = LoadConversation(baseFilePath, node.InnerText);
                        break;

                    case "TitleScreen":

                        // Get title color
                        float r = 1;
                        float g = 1;
                        float b = 1;
                        float.TryParse(node.Attributes["R"]?.Value ?? "1", out r);
                        float.TryParse(node.Attributes["G"]?.Value ?? "1", out g);
                        float.TryParse(node.Attributes["B"]?.Value ?? "1", out b);

                        float duration = 1;
                        float.TryParse(node.Attributes["Duration"].Value ?? "1", out duration);

                        currentScene = new TitleScene()
                        {
                            Content = node.InnerText,
                            Color = new SolidColorBrush(Color.FromArgb(255, (byte)(r * 255.0f), (byte)(g * 255.0f), (byte)(b * 255.0f))),
                            Duration = duration
                        };
                        break;

                    case "PillSequence":
                        PillScene scene = new PillScene();
                        scene.Content = "Pill Sequence";
                        string NumPills = node.Attributes["NumPills"]?.Value ?? "1";
                        int pillCount = 1;
                        int.TryParse(NumPills, out pillCount);
                        scene.NumPills = pillCount;
                        currentScene = scene;
                        break;

                    case "DrawingState":
                        DrawingScene drawingScene = new DrawingScene();
                        drawingScene.Content = node.InnerText;
                        drawingScene.DrawingFilePath = node.Attributes["FilePath"]?.Value ?? "";
                        drawingScene.Color = Brushes.Gray;
                        currentScene = drawingScene;
                        break;

                    default:
                        currentScene = null;
                        break;
                }

                if(currentScene != null)
                    result.Scenes.Add(currentScene);
            }

            return result;
        }

        static public ConversationScene LoadConversation(string rootFolder, string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(rootFolder + path);

            IList<ConversationPrompt> prompts = new List<ConversationPrompt>();

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                switch (node.Name)
                {
                    case "Prompt":
                        prompts.Add(GetPrompt(node));
                        break;
                    case "#comment":
                        break;
                    default:
                        throw new Exception("Unrecognized xml node name in " + path + " name is " + node.Name + " expected Prompt");
                }
            }

            ConversationScene res = new ConversationScene();
            res.Prompts = prompts;
            res.Color = prompts?.FirstOrDefault()?.InitialColor ?? Brushes.HotPink;
            res.Content = path;
            return res;
        }

        static public ConversationPrompt GetPrompt(XmlNode node)
        {
            IList<string> promptText = new List<string>();
            IList<Brush> colors = new List<Brush>();
            foreach (XmlNode child in node.ChildNodes)
            {
                switch (child.Name)
                {
                    case "Text":
                        promptText.Add(child.InnerText);
                        break;
                    case "Response":
                        break;
                    case "Color":
                        colors.Add(GetColor(child));
                        break;
                    case "Triggers":
                        break;
                    case "ObscuredWords":
                        break;
                    case "#comment":
                        break;
                    default:
                        throw new Exception("Unrecognized xml node in GetPrompt " + " name is " + child.Name + " expected Text or Response");
                }
            }

            return new ConversationPrompt()
            {
                Text = promptText,
                Colors = colors,
                TransitionText = node?.Attributes["TransitionText"]?.Value ?? ""
            };
        }

        static public Brush GetColor(XmlNode node)
        {
            decimal r = 0;
            decimal g = 0;
            decimal b = 0;
            decimal a = 0;

            foreach (XmlNode child in node.ChildNodes)
            {
                switch (child.Name)
                {
                    case "r":
                        decimal.TryParse(child.InnerText, out r);
                        break;
                    case "g":
                        decimal.TryParse(child.InnerText, out g);
                        break;
                    case "b":
                        decimal.TryParse(child.InnerText, out b);
                        break;
                    case "a":
                        decimal.TryParse(child.InnerText, out a);
                        break;
                    case "#comment":
                        break;
                    default:
                        throw new Exception("Unrecognized xml node in GetColor " + " name is " + child.Name + " expected r, g, b, or a");
                }
            }

            return new SolidColorBrush(Color.FromArgb((byte)(a * 255.0M), (byte)(r * 255.0M), (byte)(g * 255.0M), (byte)(b * 255.0M)));
        }
    }
}
