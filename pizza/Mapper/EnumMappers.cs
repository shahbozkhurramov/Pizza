using pizza.Entity;

namespace pizza.Mapper
{
    public static class EnumMappers
    {
        public static Entity.EPizzaStockStatus ToEntityPizzaStatus(this Model.EPizzaStockStatus? status)
        {
            return status switch
            {
                Model.EPizzaStockStatus.In => Entity.EPizzaStockStatus.In,
                _ => Entity.EPizzaStockStatus.Out
            };
        }
    }
}