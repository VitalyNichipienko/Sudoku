using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GenerateFieldPanel : Panel
    {
        [SerializeField] private TMP_InputField fieldComplexityInput;
        [SerializeField] private Button startButton;
        [SerializeField] private Button returnButton;

        private const int MinValue = 10;
        private const int MaxValue = 50;
        
        public Button StartButton => startButton;
        public Button ReturnButton => returnButton;
        public int FieldComplexity => Convert.ToInt32(fieldComplexityInput.text);

        private void Awake()
        {
            fieldComplexityInput.onValueChanged.AddListener(ValidateInput);
        }

        private void OnDestroy()
        {
            fieldComplexityInput.onValueChanged.RemoveListener(ValidateInput);
        }

        private void ValidateInput(string newValue)
        {
            try
            {
                int value = Convert.ToInt32(newValue);
                value = Mathf.Clamp(value, MinValue, MaxValue);
                fieldComplexityInput.text = value.ToString();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }
    }
}
