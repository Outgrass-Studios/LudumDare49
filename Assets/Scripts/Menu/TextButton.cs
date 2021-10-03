using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class TextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string leftText = ">";
        public string rightText = "<";

        string baseText;
        TextMeshProUGUI text;

        public void OnPointerEnter(PointerEventData eventData) =>
            ChangeText($"{leftText}{baseText}{rightText}");

        public void OnPointerExit(PointerEventData eventData) =>
            ChangeText(baseText);

        void ChangeText(string text)
        {
            if (this.text == null) return;
            this.text.text = text;
        }

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            if (text == null) return;
            baseText = text.text;
        }

        private void OnDisable()
        {
            ChangeText(baseText);
        }
    }
}