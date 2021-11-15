using pizza.Entity;

namespace pizza.Mapper
{
    public static class ModelEntityMapper
    {
        public static Entity.Pizza ToPizzaEntity(this Model.NewPizza newPizza)
            =>new Entity.Pizza(
                title: newPizza.Title,
                shortName: newPizza.ShortName,
                stockStatus: newPizza.StockStatus.ToEntityPizzaStatus(),
                ingredients: newPizza.Ingredients is null ? string.Empty : string.Join(',', newPizza.Ingredients),
                price: newPizza.Price
            );
        public static Entity.Pizza ToPizzaEntity(this Model.UpdatedPizza newPizza)
            =>new Entity.Pizza(
                title: newPizza.Title,
                shortName: newPizza.ShortName,
                stockStatus: newPizza.StockStatus.ToEntityPizzaStatus(),
                ingredients: newPizza.Ingredients is null ? string.Empty : string.Join(',', newPizza.Ingredients),
                price: newPizza.Price)
                {
                    Id = newPizza.Id
                };
    }
}