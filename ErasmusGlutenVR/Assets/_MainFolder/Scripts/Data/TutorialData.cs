using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    [CreateAssetMenu(menuName = "ErasmusGlutenVR/New Tutorial Data", fileName = "NewTutorialData.asset")]
    public partial class TutorialData : ScriptableObject
    {
        [Header("Tutorial sequence strings")]
        [SerializeField] private List<string> _tutorialStrings = new List<string>();

        public List<string> TutorialStrings
        {
            get { return _tutorialStrings; }
        }
    }
}
