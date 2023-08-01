namespace CarShop.Data.Models
{
    using System.Collections.Generic;

    using CarShop.Data.Common.Models;

    public class Transmission : BaseDeletableModel<int>
    {
        public Transmission()
        {
            this.Cars = new List<Car>();
        }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
