using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Chapter8.Q8_4PowerSet;


namespace Tests.Chapter8
{
    public class Q8_4
    {
        [FactAttribute]
        private static void EmptySet()
        {
            List<List<string>> result = get_subsets<string>(new List<string>());
            Assert.True(result.Count == 1);
            Assert.True(result[0].Count == 0);
        }

        [FactAttribute]
        private static void NullSet()
        {
            Exception actualException = Record.Exception(() => get_subsets<string>(null));
            Assert.IsType<ArgumentNullException>(actualException);
        }

        [FactAttribute]
        private static void FillUpSet()
        {
            List<string> colors = new List<string>(){
                "RED",
                "YELLOW",
                "GREEN"
            };

            List<List<string>> expectedResult = buildExpectedResult();
            List<List<string>> actualResult = get_subsets<string>(colors);
            
            Assert.Equal(actualResult.Count, expectedResult.Count);

            foreach (var actualList in actualResult)
            {
                Assert.True(expectedResultContainsActualList(expectedResult,actualList));
            }
        }

        private static bool expectedResultContainsActualList(List<List<string>> expectedResult,List<string> actualList)
        {
            foreach (var expectedList in expectedResult)
            {
                if(actualList.All(expectedList.Contains) && actualList.Count == expectedList.Count)
                    return true;
            }
            return false;
        }
        private static List<List<string>> buildExpectedResult() =>
                new List<List<string>>(){
                new List<string>(),
                new List<string>(){"RED"},
                new List<string>(){"YELLOW"},
                new List<string>(){"GREEN"},
                new List<string>(){"RED","GREEN"},
                new List<string>(){"RED","YELLOW"},
                new List<string>(){"YELLOW","GREEN"},
                new List<string>(){"YELLOW","GREEN","RED"}
            };
    }
}