namespace BasicCommandParser.ValueParsers.FloatParsing {
    public interface IFloatParser : IValueParser {
        public float Parse(ref IList<string> input);

        public IList<float> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig);

        public FloatRange ParseRange(ref IList<string> input);

        public IList<FloatRange> ParseRange(ref IList<string> input, ValueParsingConfig valueParsingConfig);
    }
}