using System;

namespace Infinitum.SolutionTest.Domain.DataModel
{
    public class SomeData
    {
        public int Id { get; private set; }

        public string Data { get; private set; }

        public int MyProperty1 { get; private set; }
        public int MyProperty2 { get; private set; }
        public int MyProperty3 { get; private set; }
        public int MyProperty4 { get; private set; }
        public int MyProperty5 { get; private set; }

        private SomeData()
        {

        }

        public void SetData(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            Data = data;
        }
    }
}
