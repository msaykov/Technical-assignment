namespace Zoo.Models
{
    using System;

    public class Animal
    {
        private const int MaxHp = 100;

        public Animal()
        {
            
        }

        public int HealthPoints { get; set; } = MaxHp;

        public bool IsDead { get; set; } = false;

        public void Starvation()
        {
            var rnd = new Random();
            var starvationScale = rnd.Next(0, 21);
            this.HealthPoints -= starvationScale;
        }

        public void Eat()
        {
            var rnd = new Random();
            var eatingScale = rnd.Next(5, 26);
            this.HealthPoints += eatingScale;
            if (this.HealthPoints > MaxHp)
            {
                this.HealthPoints = MaxHp;
            }
        }
    }
}
