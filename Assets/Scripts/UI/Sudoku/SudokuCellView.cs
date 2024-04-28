using System;
using TMPro;
using UnityEngine;

namespace UI.Sudoku
{
    public class SudokuCellView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public int Value => Convert.ToInt32(inputField.text);
    }
}
