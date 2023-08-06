namespace CarShop.Data.Models
{
    using System.Collections.Generic;

    using CarShop.Data.Common.Models;

    public class EngineType : BaseDeletableModel<int>
    {
        public EngineType()
        {
            this.Cars = new List<Car>();
        }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
