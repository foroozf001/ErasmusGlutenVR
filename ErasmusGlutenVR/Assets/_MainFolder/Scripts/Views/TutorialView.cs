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
            _text.text = tutorialData.TutorialStrings[2];
            StartCoroutine(WaitBeforeClose(GameManager.Instance.waitSecondsAfterTutorialComplete));
        }

        public void OnTutorialMiddle()
        {
            //_text.text = tutorialData.TutorialStrings[1];
        }

        public void OnTutorialStart()
        {
            _text.text = tutorialData.TutorialStrings[0];
        }

        IEnumerator WaitBeforeClose(float wait)
        {
            yield return new WaitForSeconds(wait);
            _textBalloonView.gameObject.SetActive(false); 
        }

        private void Awake()
        {
            Assert.IsNotNull(tutorialData, "tutorial data");
            Assert.IsNotNull(GetComponentInChildren<TextBalloonView>(true), "Text balloon view");
            _textBalloonView = GetComponentInChildren<TextBalloonView>(true);
            _text = _textBalloonView.GetComponentInChildren<Text>(true);
            _image = _textBalloonView.GetComponentInChildren<Image>(true);
        }
    }
}
