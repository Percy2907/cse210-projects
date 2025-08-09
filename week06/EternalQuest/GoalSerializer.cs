using System;

namespace EternalQuest
{
    public static class GoalSerializer
    {
        public static Goal Deserialize(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split('|');
            string type = parts[0];

            try
            {
                switch (type)
                {
                    case "SimpleGoal":
                        if (parts.Length != 5) return null;
                        var simple = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        bool isComplete = bool.Parse(parts[4]);
                        if (isComplete)
                        {
                            simple.RecordEvent();
                        }
                        return simple;

                    case "EternalGoal":
                        if (parts.Length != 4) return null;
                        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));

                    case "ChecklistGoal":
                        if (parts.Length != 7) return null;
                        var checklist = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                          int.Parse(parts[4]), int.Parse(parts[6]));
                        int current = int.Parse(parts[5]);
                        for (int i = 0; i < current; i++) checklist.RecordEvent();
                        return checklist;

                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}