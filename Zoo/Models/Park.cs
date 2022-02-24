namespace Zoo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Park
    {
        public Park()
        {
            this.Animals = new List<Animal>();
        }

        public ICollection<Animal> Animals { get; set; }

        public int AnimalsCount() 
        {
            return this.Animals.Count();
        }
    }
}
