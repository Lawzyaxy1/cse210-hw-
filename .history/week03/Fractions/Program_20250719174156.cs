using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Demonstrating Fraction Class ---");

            // 1. Demonstrate Constructors

            Console.WriteLine("\n1. Demonstrating Constructors:");

            // Constructor 1: No parameters (initializes to 1/1)
            Fraction fraction1 = new Fraction();
            Console.WriteLine($"Fraction 1 (no params): {fraction1.GetFractionString()}"); // Expected: 1/1
            Console.WriteLine($"Decimal Value: {fraction1.GetDecimalValue()}"); // Expected: 1

            // Constructor 2: One parameter (initializes denominator to 1)
            Fraction fraction2 = new Fraction(5); // Initializes to 5/1
            Console.WriteLine($"Fraction 2 (one param, 5): {fraction2.GetFractionString()}"); // Expected: 5/1
            Console.WriteLine($"Decimal Value: {fraction2.GetDecimalValue()}"); // Expected: 5

            // Constructor 3: Two parameters (top and bottom)
            Fraction fraction3 = new Fraction(3, 4); // Initializes to 3/4
            Console.WriteLine($"Fraction 3 (two params, 3, 4): {fraction3.GetFractionString()}"); // Expected: 3/4
            Console.WriteLine($"Decimal Value: {fraction3.GetDecimalValue()}"); // Expected: 0.75

            Fraction fraction4 = new Fraction(1, 3); // Initializes to 1/3
            Console.WriteLine($"Fraction 4 (two params, 1, 3): {fraction4.GetFractionString()}"); // Expected: 1/3
            Console.WriteLine($"Decimal Value: {fraction4.GetDecimalValue()}"); // Expected: 0.333...

            // 2. Demonstrate Getters and Setters (Properties)

            Console.WriteLine("\n2. Demonstrating Getters and Setters:");

            // Using fraction3 (3/4) for demonstration
            Console.WriteLine($"\nInitial Fraction 3: {fraction3.GetFractionString()} (Top: {fraction3.Top}, Bottom: {fraction3.Bottom})");

            // Using setters to change values
            fraction3.Top = 7;
            fraction3.Bottom = 8;
            Console.WriteLine($"Modified Fraction 3 to 7/8: {fraction3.GetFractionString()} (Top: {fraction3.Top}, Bottom: {fraction3.Bottom})"); // Expected: 7/8

            // Try setting bottom to zero (should show warning and not change)
            fraction3.Bottom = 0;
            Console.WriteLine($"Attempted to set Bottom to 0. Current Fraction 3: {fraction3.GetFractionString()}"); // Expected: 7/8 (or previous valid value)

            // 3. Verify Representations (already done implicitly above, but explicitly here)

            Console.WriteLine("\n3. Verifying Representations (GetFractionString and GetDecimalValue):");

            // Test with a new fraction
            Fraction testFraction = new Fraction(10, 3);
            Console.WriteLine($"\nTest Fraction: {testFraction.GetFractionString()}"); // Expected: 10/3
            Console.WriteLine($"Decimal Value: {testFraction.GetDecimalValue()}"); // Expected: 3.333...

            testFraction.Top = 1;
            testFraction.Bottom = 2;
            Console.WriteLine($"\nTest Fraction (modified to 1/2): {testFraction.GetFractionString()}"); // Expected: 1/2
            Console.WriteLine($"Decimal Value: {testFraction.GetDecimalValue()}"); // Expected: 0.5

            Console.WriteLine("\n--- End of Demonstration ---");
        }
    }
}
