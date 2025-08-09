using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class QuestManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;

        public QuestManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
        }

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
        public int Score => _score;
        public int Level => _level;

        public void AddGoal(Goal goal)
        {
            if (goal != null) _goals.Add(goal);
        }

        public void CreateGoalFromConsole()
        {
            Console.WriteLine("Select goal type:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter description: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Enter points (integer): ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points.");
                return;
            }

            switch (choice)
            {
                case 1:
                    AddGoal(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    AddGoal(new EternalGoal(name, description, points));
                    break;
                case 3:
                    Console.Write("Enter target count (integer): ");
                    if (!int.TryParse(Console.ReadLine(), out int target)) { Console.WriteLine("Invalid."); return; }
                    Console.Write("Enter bonus points (integer): ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus)) { Console.WriteLine("Invalid."); return; }
                    AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        public void RecordEventForGoal(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }

            Goal goal = _goals[index];
            int earned = goal.RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points! Total score: {_score}");
            CheckLevelUp();
        }

        public void RecordEventFromConsole()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            Console.WriteLine("Select a goal to record:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
            }

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            RecordEventForGoal(choice - 1);
        }

        public void ShowGoals()
        {
            Console.WriteLine("\n=== Your Goals ===");
            if (_goals.Count == 0) Console.WriteLine("[No goals yet]");
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
                }
            }
            Console.WriteLine($"Score: {_score} | Level: {_level}");
        }

        private void CheckLevelUp()
        {
            while (_score >= _level * 1000)
            {
                _level++;
                Console.WriteLine($"🎉 Level Up! You are now Level {_level}!");
            }
        }

        public void SaveToFile(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(_score);
                    sw.WriteLine(_level);
                    foreach (var g in _goals)
                    {
                        sw.WriteLine(g.Serialize());
                    }
                }
                Console.WriteLine("Saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving: {ex.Message}");
            }
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            try
            {
                _goals.Clear();
                using (StreamReader sr = new StreamReader(path))
                {
                    if (!int.TryParse(sr.ReadLine(), out _score)) _score = 0;
                    if (!int.TryParse(sr.ReadLine(), out _level)) _level = 1;

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Goal g = Goal.Deserialize(line);
                        if (g != null) _goals.Add(g);
                    }
                }
                Console.WriteLine("Loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading: {ex.Message}");
            }
        }
    }
}