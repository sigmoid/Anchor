using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media;
using Anchor.Managers;
using Anchor.Views;

namespace Anchor.Model
{
    public class ConversationPrompt
    {
        public IList<string> Text;
        public IList<Brush> Colors;
        public IList<string> Triggers;
        public IList<string> ObscuredWords;
        public string Sound;
        public float SoundDelay;
        public ConversationResponse Response;
        public bool IsEnd = false;
        public bool IsKill = true;
        public bool IsZoomIn = false;
        public int Sequence = -1;
        public bool InsideHead = false;
        public string TransitionText = "";

        public string InitialText
        {
            get
            {
                return Text?.FirstOrDefault() ?? "";
            }
        }

        public Brush InitialColor
        {
            get
            {
                return Colors?.FirstOrDefault() ?? Brushes.HotPink;
            }
        }
    }

    public class ConversationResponse
    {
        IList<SentenceFragment> Fragments;
        float Speed;
        Brush Color;
        string WordBank;
        float WordFrequency;
        bool SolidWords;
        float ChannelSize = 500;
        bool AllowNonsense = false;
        bool RequireCoreOnly = false;
        bool Drunk = false;
        bool Tremor = false;
        bool ShowBlur = false;
    }

    public class SentenceFragment
    {
        string Text;
        float Attraction;
        bool IsIntrusive = false;
    }


    public class ConversationScene: DialogueScene
    {
        public ConversationScene()
        {
            EditCommand = new RelayCommand(() => Edit());
            this.Type = DialogueSceneType.Conversation;
        }

        #region Properties

        public IList<ConversationPrompt> Prompts
        {
            get;
            set;
        }

        #endregion

        public override void Edit()
        {
            ViewManager.Instance.ShowView(new ConversationView(), new ConversationViewModel(this));
        }
    }
}
