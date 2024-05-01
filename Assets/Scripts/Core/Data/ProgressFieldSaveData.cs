using Newtonsoft.Json;
using Sudoku;

namespace Core.Data
{
    public class ProgressFieldSaveData
    {
        [JsonProperty("generatedField")]
        public SudokuField GeneratedField { get; set; }
        
        [JsonProperty("solutionField")]
        public SudokuField SolutionField { get; set; }

        [JsonProperty("currentField")]
        public SudokuField CurrentField { get; set; }
    }
}