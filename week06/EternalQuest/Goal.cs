using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public int Points { get { return _points; } }

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStatus();
        public abstract string Serialize();
        public static Goal Deserialize(string line) => GoalSerializer.Deserialize(line);
    }
}