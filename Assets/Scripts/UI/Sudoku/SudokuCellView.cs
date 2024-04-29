using Sudoku;
using TMPro;
using UnityEngine;

namespace UI.Sudoku
{
    public class SudokuCellView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public TMP_InputField InputField => inputField;
        
        public void Init(Cell cell)
        {
            inputField.text = cell.Value != 0 ? cell.Value.ToString() : "";
            inputField.interactable = cell.IsEditable;
        }
    }
}
