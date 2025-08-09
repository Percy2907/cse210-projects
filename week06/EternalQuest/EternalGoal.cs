using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            return Points;
        }

        public override bool IsComplete() => false;

        public override string GetStatus()
        {
            return "[∞] " + $"{Name} ({Description})";
        }

        public override string Serialize()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }
    }
}