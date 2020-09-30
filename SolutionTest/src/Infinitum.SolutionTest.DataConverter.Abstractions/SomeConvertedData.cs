namespace Infinitum.SolutionTest.DataConverter.Abstractions
{
    public class SomeConvertedData
    {
        public string ConvertedData { get; private set; }

        private SomeConvertedData()
        {

        }

        public static SomeConvertedData CreateNew(string data)
        {
            return new SomeConvertedData() { ConvertedData = data };
        }
    }
}
