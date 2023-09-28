namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    public struct DateTimeRange {

        public DateTimeRange(DateTime start, DateTime end) {
            this.Start = start;
            this.End = end;
        }

        public DateTime Start;
        public DateTime End;
    }
}