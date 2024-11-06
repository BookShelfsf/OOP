namespace BMIMonitor.ReferenceTypes
{
    using BMIMonitor.ValueTypes;
    using System.Diagnostics.Metrics;

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI => new Measurement(Weight, Height).BMI;

        public Person() { }
    }
}
