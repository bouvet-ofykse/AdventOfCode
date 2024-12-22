
namespace AdventOfCode2024._09;

public static class December9_PartOne
{

    private static List<int> _currentDiskMap = new ();
    public static long CalculateFilesystemChecksum()
    {
        long checksum = 0;
        var diskMap = File.ReadAllText("../../../09/PuzzleInput.txt").ToList().Select(c => int.Parse(c.ToString())).ToList();
        var blockId = 0;

        for (int block = 0; block < diskMap.Count; block++)
        {
            if (block == 0)
            {
                _currentDiskMap.AddRange(CreateFileBlocks(diskMap[block], blockId));
                blockId++;
            } 
            else if (block % 2 == 0)
            {
                _currentDiskMap.AddRange(CreateFileBlocks(diskMap[block], blockId));
                blockId++;
            }
            else
            {
                _currentDiskMap.AddRange(CreateEmptyBlocks(diskMap[block]));
            }
        }
        
        Console.WriteLine("Done writing disk map");

        while (!IsFinished())
        {
            var firstVacantBlock = _currentDiskMap.IndexOf(-1);
            var blockToMove = _currentDiskMap.FindLastIndex(block => block != -1);
            MoveBlock(firstVacantBlock, blockToMove);
        }

        _currentDiskMap.ForEach(Console.Write);
        Console.WriteLine();
        Console.WriteLine("Done moving blocks");
        Console.WriteLine($"Calculating checksum for {_currentDiskMap.Count(block => block != -1)} blocks");
        for (int i = 0; i < _currentDiskMap.Count(block => block != -1); i++)
        {
            
            var first = long.Parse(_currentDiskMap[i].ToString());
            var second = i;
            checksum += first * second;
        }
        
        return checksum;
    }

    private static void MoveBlock(int moveToIndex, int freeUpIndex)
    {
        _currentDiskMap[moveToIndex] = _currentDiskMap.Last(block => block != -1);
        _currentDiskMap[freeUpIndex]= -1;
    }

    private static List<int> CreateFileBlocks(int numberOfBlocks, int blockId)
    {
        var fileBlocks = new List<int>();
        for (int i = 0; i < numberOfBlocks; i++)
        {
            fileBlocks.Add(blockId);
        }

        return fileBlocks.ToList();
    }
    private static List<int> CreateEmptyBlocks(int blocks)
    {
        var emptyBlocks = new List<int>();
        for (int i = 0; i < blocks; i++)
        {
            emptyBlocks.Add(-1);
        }

        return emptyBlocks.ToList();
    }

    private static bool IsFinished()
    {
        var lastBlockThatIsANumber = _currentDiskMap.Last(block => block != -1);
        var replacedBlocks = _currentDiskMap.Slice(0,_currentDiskMap.LastIndexOf(lastBlockThatIsANumber));
        return !replacedBlocks.Contains(-1);
    }
}
