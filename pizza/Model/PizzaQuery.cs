using System;
using Microsoft.AspNetCore.Mvc;

namespace pizza.Model
{
    public class PizzaQuery
    {
        [FromQuery]
        public Guid Id { get; set; }
    }
}