namespace AdventOfCode2024._1;

public class December1_PartTwo
{
    public static int CalculateSimilarity()
    {
            string line;
            string content = File.ReadAllText("../../../1/PuzzleInput.txt");
            int sum = 0;
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            using (StringReader reader = new StringReader(content))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    list1.Add(int.Parse(line.Split(",")[0]));
                    list2.Add(int.Parse(line.Split(",")[1]));
                }
            }
            
            while (list1.Any())
            {
                var numberToSearchFor = list1.First();
                var occurrences = list2.Count(x => x == numberToSearchFor);


                sum += occurrences * numberToSearchFor;
                list1.RemoveAt(0);
            }

            return sum;
    } 

}