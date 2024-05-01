using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class LoadButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI fileName;

        public Button Button => button;
        
        public event Action<string> OnLoad; 

        public void Init(string saveName)
        {
            fileName.text = saveName;
        }

        private void Awake()
        {
            button.onClick.AddListener(OnLoadButtonClick);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnLoadButtonClick);
        }

        private void OnLoadButtonClick()
        {
            OnLoad?.Invoke(fileName.text);
        }
    }
}
