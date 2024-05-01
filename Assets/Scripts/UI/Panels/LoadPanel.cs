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
        [SerializeField] private SaveItem saveItemPrefab;
        [SerializeField] private SaveType saveType;

        private SaveManager _saveManager;
        private CommonFactory _commonFactory;

        public List<SaveItem> SaveItems { get; private set; }

        public Button ReturnButton => returnButton;
        
        [Inject]
        private void Construct(SaveManager saveManager, CommonFactory commonFactory)
        {
            _saveManager = saveManager;
            _commonFactory = commonFactory;
        }

        public override void Hide()
        {
            if (SaveItems == null)
                return;
            
            base.Hide();

            for (int i = 0; i < SaveItems.Count; i++)
            {
                Destroy(SaveItems[i].gameObject);
            }

            SaveItems.Clear();
        }

        public void AddButtonsToWindow()
        {
            SaveItems = new List<SaveItem>();
            List<string> saveFiles = _saveManager.GetSaveFiles(saveType);

            for (var i = 0; i < saveFiles.Count; i++)
            {
                var saveName = saveFiles[i];
                SaveItem saveItem = _commonFactory.Instantiate(saveItemPrefab, content);
                saveItem.Init(saveName);
                SaveItems.Add(saveItem);
            }
        }

        public void DeleteSaveItemFromWindow(SaveItem saveItem)
        {
            if (!SaveItems.Contains(saveItem))
                return;

            SaveItems.Remove(saveItem);
            Destroy(saveItem.gameObject);
        }
    }
}
