using System.Collections.Generic;
using Core.Data;
using Core.Infrastructure;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Panels
{
    public class LoadPanel : Panel
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private Button returnButton;
        [SerializeField] private LoadButton loadButtonPrefab;
        [SerializeField] private SaveType saveType;

        private SaveManager _saveManager;
        private CommonFactory _commonFactory;

        public List<LoadButton> LoadButtons { get; private set; }

        public Button ReturnButton => returnButton;
        
        [Inject]
        private void Construct(SaveManager saveManager, CommonFactory commonFactory)
        {
            _saveManager = saveManager;
            _commonFactory = commonFactory;
        }

        public override void Hide()
        {
            if (LoadButtons == null)
                return;
            
            base.Hide();

            for (int i = 0; i < LoadButtons.Count; i++)
            {
                Destroy(LoadButtons[i].gameObject);
            }

            LoadButtons.Clear();
        }

        public void AddButtonsToWindow()
        {
            LoadButtons = new List<LoadButton>();
            List<string> saveFiles = _saveManager.GetSaveFiles(saveType);

            for (var i = 0; i < saveFiles.Count; i++)
            {
                var saveName = saveFiles[i];
                LoadButton loadButton = _commonFactory.Instantiate(loadButtonPrefab, content);
                loadButton.Init(saveName);
                LoadButtons.Add(loadButton);
            }
        }
    }
}
