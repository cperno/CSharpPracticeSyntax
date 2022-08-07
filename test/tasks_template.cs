// we use both Task and Task<T> in C# for the return data type of an asynchronous method
// Task is for methods that do not return a value
// Task<T> is for methods that do return a value of type T
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticeSyntax
{
    public class TasksTests
    {
        private async Task JustWait()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
        private async Task<int> WaitAndReturn()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            return 7;
        }

        [Fact]
        public async void TaskTest1()
        {
            await JustWait();

            Assert.Equal(7, await WaitAndReturn());
        }
    }
}