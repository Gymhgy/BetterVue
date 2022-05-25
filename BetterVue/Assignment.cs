namespace BetterVue {
    public class Assignment {
        public Assignment(string type, string originalPointVal, string points, string total) {
            Type = type;
            OriginalPointVal = originalPointVal;
            Points = points;
            Total = total;
        }

        public string Type { get; }
        public string OriginalPointVal { get; }
        public string Points { get; set; }
        public string Total { get; }
    }
}
