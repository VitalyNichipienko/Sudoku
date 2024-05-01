using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class SaveItem : MonoBehaviour
    {
        [SerializeField] private Button loadButton;
        [SerializeField] private Button deleteButton;
        [SerializeField] private TextMeshProUGUI fileName;

        public event Action<string> OnLoad; 
        public event Action<string> OnDelete;

        public void Init(string saveName)
        {
            fileName.text = saveName;
        }

        private void Awake()
        {
            loadButton.onClick.AddListener(OnLoadButtonClick);
            deleteButton.onClick.AddListener(OnDeleteButtonClick);
        }

        private void OnDestroy()
        {
            loadButton.onClick.RemoveListener(OnLoadButtonClick);
            deleteButton.onClick.RemoveListener(OnDeleteButtonClick);
        }

        private void OnLoadButtonClick()
        {
            OnLoad?.Invoke(fileName.text);
        }
        
        private void OnDeleteButtonClick()
        {
            OnDelete?.Invoke(fileName.text);
        }
    }
}
