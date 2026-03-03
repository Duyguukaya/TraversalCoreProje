namespace TraversalCoreProje.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
