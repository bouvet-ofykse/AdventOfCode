
namespace AdventOfCode2024._9;

public static class December9_PartOne
{

    private static List<char> _currentDiskMap = new ();
    public static long CalculateFilesystemChecksum()
    {
        long checksum = 0;
        var diskMap = File.ReadAllText("../../../9/PuzzleInput.txt").ToList().Select(c => int.Parse(c.ToString())).ToList();
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
        // Console.WriteLine(_currentDiskMap);


        while (!IsFinished())
        {
            var firstVacantBlock = _currentDiskMap.IndexOf('.');
            var blockToMove = _currentDiskMap.FindLastIndex(block => block != '.');
            MoveBlock(firstVacantBlock, blockToMove);
            // _currentDiskMap.ForEach(Console.Write);
            // Console.WriteLine();
        }

        _currentDiskMap.ForEach(Console.Write);
        Console.WriteLine();
        Console.WriteLine("Done moving blocks");
        for (int i = 0; i < _currentDiskMap.Count(block => block != '.'); i++)
        {
            if (int.Parse(_currentDiskMap[i].ToString()) == -1)
            {
                Console.WriteLine($"Something went wrong");
            }

            if (i % 10000 == 0)
            {
                Console.WriteLine($"Done calculating {i} blocks"); 
            }
            
            var first = long.Parse(_currentDiskMap[i].ToString());
            var second = i;
            checksum += first * second;
        }
        
        return checksum;
    }

    private static void MoveBlock(int moveToIndex, int freeUpIndex)
    {
        _currentDiskMap[moveToIndex] = _currentDiskMap.Last(block => block != '.');
        _currentDiskMap[freeUpIndex]= '.';
    }

    private static List<char> CreateFileBlocks(int numberOfBlocks, int blockId)
    {
        var fileBlocks = "";
        for (int i = 0; i < numberOfBlocks; i++)
        {
            fileBlocks += blockId.ToString();
        }

        return fileBlocks.ToList();
    }
    private static List<char> CreateEmptyBlocks(int blocks)
    {
        var emptyBlocks = "";
        for (int i = 0; i < blocks; i++)
        {
            emptyBlocks += ".";
        }

        return emptyBlocks.ToList();
    }

    private static bool IsFinished()
    {
        var lastBlockThatIsANumber = _currentDiskMap.Last(block => block != '.');
        var replacedBlocks = _currentDiskMap.Slice(0,_currentDiskMap.LastIndexOf(lastBlockThatIsANumber));
        return !replacedBlocks.Contains('.');
    }
 
}
