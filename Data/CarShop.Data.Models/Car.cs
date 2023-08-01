﻿namespace CarShop.Data.Models
{
    using System;

    using CarShop.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {
        public DateTime DateOfCreation { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int TransimmisionId { get; set; }

        public virtual Transmission Transmission { get; set; }

        public int EngineTypeId { get; set; }

        public virtual EngineType EngineType { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}
