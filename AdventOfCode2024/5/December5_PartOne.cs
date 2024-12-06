namespace AdventOfCode2024._4;

public static class December5_PartOne
{
    static List<Rule> rules = new ();
    static List<List<int>> updates = new ();

    public static int CalculateSafeUpdates()
    {
        string content = File.ReadAllText("../../../5/PuzzleInput.txt");
        int sum = 0;
        string? line;

        using (StringReader reader = new StringReader(content))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains('|'))
                {
                    if (rules.Any(rule => rule.PageNumber == int.Parse(line.Split('|')[0])))
                    {
                        // Use rule that are already added
                        Rule rule = rules.Single((rule => rule.PageNumber == int.Parse(line.Split('|')[0])));
                        rule.After.Add(int.Parse(line.Split('|')[1]));
                    }
                    else
                    {
                        // Add new rule
                        rules.Add(new Rule{ PageNumber = int.Parse(line.Split('|')[0]), After = new List<int> {int.Parse(line.Split('|')[1])} });

                    }
                } else if (line.Contains(','))
                {
                    var updateValues = line.Split(',').Select(x => int.Parse(x)).ToList();
                    updates.Add(updateValues);
                }
            }
        }

        PopulateBeforeInAllRules();

        foreach (var update in updates)
        {
            sum += PagesAreInCorrectOrder(update);
        }
        
        return sum;
    }

    private static int PagesAreInCorrectOrder(List<int> update)
    {

        for (int i = 0; i < update.Count; i++)
        {
            var updateNumbersBefore = update.Slice(0, i).Where(x => x != update[i]).ToList();
            var updateNumbersAfter = update.Slice(i, update.Count - i).Where(x => x != update[i]).ToList();

            if (rules.Any(rule => rule.PageNumber == update[i]))
            {
                Rule rule = rules.Single(rule => rule.PageNumber == update[i]);
                if (!updateNumbersBefore.All(x => rule.Before.Contains(x))) return 0;
                if (!updateNumbersAfter.All(x => rule.After.Contains(x))) return 0;
            }

        }
        return update[update.Count/2];
    }

    private static void PopulateBeforeInAllRules()
    {
        foreach (var rule in rules)
        {
            foreach (var after in rule.After)
            {
                if (rules.Any(rule => rule.PageNumber == after))
                {
                    rules.Single(rule => rule.PageNumber == after).Before.Add(rule.PageNumber);
                }
            }
        }
    }
    
}

public class Rule
{
    public int PageNumber { get; set; }
    public List<int> Before { get; set; } = new ();
    public List<int> After { get; set; } = new ();

}