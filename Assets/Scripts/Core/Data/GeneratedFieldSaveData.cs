using Newtonsoft.Json;
using Sudoku;

namespace Core.Data
{
    public class GeneratedFieldSaveData
    {
        [JsonProperty("generatedField")]
        public SudokuField GeneratedField { get; set; }

        [JsonProperty("solutionField")]
        public SudokuField SolutionField { get; set; }
    }
}