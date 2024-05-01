namespace Core.Data
{
    public enum StartType
    {
        GenerateNewField,
        LoadField,
        LoadProgress
    }
    
    public class StartGameData
    {
        public string FileName { get; private set; }
        public int Complexity { get; private set; }
        public StartType StartType { get; private set; }

        public void Init(StartType startType, int complexity)
        {
            StartType = startType;
            Complexity = complexity;
        }
        
        public void Init(StartType startType, string fileName)
        {
            StartType = startType;
            FileName = fileName;
        }
    }
}
