using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (_currentCount >= _targetCount)
                return 0;

            _currentCount++;
            if (_currentCount >= _targetCount)
            {

                return Points + _bonusPoints;
            }
            return Points;
        }

        public override bool IsComplete() => _currentCount >= _targetCount;

        public override string GetStatus()
        {
            return (IsComplete() ? "[X] " : "[ ] ") +
                   $"{Name} ({Description}) -- Completed {_currentCount}/{_targetCount}";
        }

        public override string Serialize()
        {
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
        }
    }
}