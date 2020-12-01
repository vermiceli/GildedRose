using System.Linq;
using System.Text;
using GildedRose.Console;
using Newtonsoft.Json;

namespace GildedRose.Tests
{
    /// <summary>
    /// A class that helps create tests to match existing functionality
    /// </summary>
    public static class ExistingStateValidatorHelper
    {
        /// <summary>
        /// A method to generate C# code for testing existing functionality to help build comfort that changes won't break existing functionality
        /// </summary>
        /// <param name="app">The application with the items to test</param>
        /// <returns>A string with C# code that can be pasted into a test</returns>
        public static string GenerateTests(Program app)
        {
            StringBuilder builder = new StringBuilder();
            int dayNumber = 1;

            var oldState = string.Empty;
            var newState = JsonConvert.SerializeObject(app.Items.Select(i => i.Quality)); 

            while (oldState != newState)
            {
                ExistingStateValidatorHelper.BuildDayResults(builder, $"day {dayNumber} results", app);

                builder.AppendLine("app.UpdateQuality();");
                builder.AppendLine();
                app.UpdateQuality();
                dayNumber++;

                oldState = newState;
                newState = JsonConvert.SerializeObject(app.Items.Select(i => i.Quality));
            }

            ExistingStateValidatorHelper.BuildDayResults(builder, "quality now 0 test", app);

            return builder.ToString();
        }

        private static void BuildDayResults(StringBuilder builder, string comment, Program app)
        {
            builder.AppendLine($"// {comment}");
            for (int i = 0; i < app.Items.Count; i++)
            {
                builder.AppendLine($"Assert.Equal({app.Items[i].Quality}, app.Items[{i}].Quality); // {app.Items[i].Name}");
                builder.AppendLine($"Assert.Equal({app.Items[i].SellIn}, app.Items[{i}].SellIn); // {app.Items[i].Name}");
            }
        }
    }
}