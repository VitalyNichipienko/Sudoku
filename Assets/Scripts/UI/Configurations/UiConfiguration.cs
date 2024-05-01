using UnityEngine;

namespace UI.Configurations
{
    [CreateAssetMenu(menuName = "Configurations/UI/Create UI configuration", fileName = "UiConfiguration")]
    public class UiConfiguration : ScriptableObject
    {
        [SerializeField] private Color trueSolutionColor;
        [SerializeField] private Color falseSolutionColor;
        [SerializeField] private Color messageTextColor;
        
        public Color TrueSolutionColor => trueSolutionColor;
        public Color FalseSolutionColor => falseSolutionColor;
        public Color MessageTextColor => messageTextColor;
    }
}
