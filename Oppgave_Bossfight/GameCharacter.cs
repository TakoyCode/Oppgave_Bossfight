namespace Oppgave_Bossfight
{
    internal class GameCharacter
    {
        public string Name { get; }
        public int Health { get; private set; }
        private int _strength;
        private int _stamina;
        private readonly int  _maxStamina;

        public GameCharacter(string name, int health, int strength, int stamina)
        {
            Name = name;
            Health = health;
            _strength = strength;
            _maxStamina = stamina;
            _stamina = stamina;
        }

        public void Fight(GameCharacter character)
        {
            if (_stamina >= 10)
            {
                character.Health -= _strength;
                _stamina -= 10;
                Console.WriteLine($"{Name} hit {character.Name} for {_strength} dmg, {character.Name} has {character.Health} left");
            }
            else
            {
                Recharge();
            }
        }

        public void Recharge()
        {
            _stamina = _maxStamina;
            Console.WriteLine($"{Name} took a break, to recharge their stamina.");
        }

        public void RandomizeStrength(int from, int to)
        {
            var r = new Random();
            _strength = r.Next(from, to);
        }
    }
}
