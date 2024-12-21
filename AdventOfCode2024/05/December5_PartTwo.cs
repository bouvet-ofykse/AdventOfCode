using AdventOfCode2024._4;

namespace AdventOfCode2024._05;

public static class December5_PartTwo
{
    static List<Rule> rules = new ();
    static List<List<int>> updates = new ();
    static List<List<int>> incorrectlyOrderedUpdates = new ();
    
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
            if (!PagesAreInCorrectOrder(update))
            {
                incorrectlyOrderedUpdates.Add(update);
            }
        }

        return incorrectlyOrderedUpdates
            .Select(update =>
            {
                update.Sort((a, b) => rules.Any(x => x.PageNumber == a) && rules.Single(x => x.PageNumber == a).After.Any(x => x == b) ? 1 : -1);
                return update[update.Count / 2];
            })
            .Sum();
    }


    private static bool PagesAreInCorrectOrder(List<int> update)
    {

        for (int i = 0; i < update.Count; i++)
        {
            var updateNumbersBefore = update.Slice(0, i).Where(x => x != update[i]).ToList();
            var updateNumbersAfter = update.Slice(i, update.Count - i).Where(x => x != update[i]).ToList();

            if (rules.Any(rule => rule.PageNumber == update[i]))
            {
                Rule rule = rules.Single(rule => rule.PageNumber == update[i]);
                if (!updateNumbersBefore.All(x => rule.Before.Contains(x))) return false;
                if (!updateNumbersAfter.All(x => rule.After.Contains(x))) return false;
            }

        }
        return true;
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
