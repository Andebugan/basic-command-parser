namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    public struct DateTimeRange {

        public DateTimeRange(DateTime start, DateTime end) {
            this.Start = start;
            this.End = end;
        }

        DateTime Start;
        DateTime End;
    }
}