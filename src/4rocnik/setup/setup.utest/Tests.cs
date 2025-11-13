using System;
using Xunit;

namespace setup.utest
{
    public class Tests
    {
        [Fact]
        public void happy_case_sum()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 + 5");
            Assert.Equal(result, "4 + 5 = 9");
        }
        
        [Fact]
        public void unhappy_case_sum()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 + 5");
            Assert.NotEqual(result, "4 + 5 = -9");
        }
        
        [Fact]
        public void happy_case_divide()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("5 - 5");
            Assert.Equal(result, "5 - 5 = 0");
        }
        
        [Fact]
        public void unhappy_case_divide()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 - 5");
            Assert.NotEqual(result, "4 - 5 = -9");
        }
        
        [Fact]
        public void happy_case_multiply()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 * 5");
            Assert.Equal(result, "4 * 5 = 20");
        }
        
        [Fact]
        public void unhappy_case_multiply()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 * 5");
            Assert.NotEqual(result, "4 * 5 = -9");
        }
        
        [Fact]
        public void happy_case_deleno()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("10 / 5");
            Assert.Equal(result, "10 / 5 = 2");
        }
        
        [Fact]
        public void unhappy_case_deleno()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 / 5");
            Assert.NotEqual(result, "4 / 5 = -9");
        }
        
        [Fact]
        public void happy_case_mocnina()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("2 ** 2");
            Assert.Equal(result, "2 ** 2 = 4");
        }
        
        [Fact]
        public void unhappy_case_mocnina()
        {
            var calculator = new Calculator();
            
            var result = calculator.Solve("4 ** 5");
            Assert.NotEqual(result, "4 ** 5 = -9");
        }
    }
}