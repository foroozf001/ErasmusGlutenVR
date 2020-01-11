using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class TutorialView : MonoBehaviour
        , ITutorial
    {
        public TutorialData tutorialData;

        private TextBalloonView _textBalloonView;
        private Text _text;
        private Image _image;

        public void OnTutorialComplete()
        {
            throw new System.NotImplementedException();
        }

        public void OnTutorialStart()
        {
            _text.text = tutorialData.TutorialStrings[0];
        }

        private void Awake()
        {
            Assert.IsNotNull(tutorialData, "tutorial data");
            Assert.IsNotNull(GetComponentInChildren<TextBalloonView>(), "Text balloon view");
            _textBalloonView = GetComponentInChildren<TextBalloonView>();
            _text = _textBalloonView.GetComponentInChildren<Text>();
            _image = _textBalloonView.GetComponentInChildren<Image>();
        }
    }
}
