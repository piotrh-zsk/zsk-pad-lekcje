namespace PR01E3.Shared.Entities
{
    public class TextStatisticsData
    {
        public int AllSymbolCount { get; set; }

        public int UniqueSymbolCount { get; set; }

        public double Entropy { get; set; }

        public List<SymbolStatisticsData>? SymbolStatistics { get; set; }
    }
}
