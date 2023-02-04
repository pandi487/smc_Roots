using TMPro;
using UnityEngine;

namespace Modules.LibUi.Examples.Test.Scripts
{
    public class ButtonTester : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText;
        [SerializeField] private int counter;
        
        public void Augment()
        {
            counter++;
            MajText();
        }

        public void Lessen()
        {
            counter--;
            MajText();
        }

        private void MajText()
        {
            counterText.text = counter.ToString();
        }
    }
}