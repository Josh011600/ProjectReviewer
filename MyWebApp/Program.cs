class Program
{
    static void Main()
    {
        // Create an object
        Test person = new Test("Joshua", 25);

        // Display initial values
        person.DisplayInfo();

        // Modify values using encapsulation
        person.Name = "John";
        person.Age = 30;

        // Show updated info
        person.DisplayInfo();

        // Try setting invalid age
        person.Age = -5; // This will trigger validation
    }
}
