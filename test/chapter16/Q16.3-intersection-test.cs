using Xunit;

using static Chapter16.Q16_3Intersection;

namespace Tests.Chapter6
{
    public class Q16_3
    {
        [FactAttribute]
        public void VerticalLinesIntersectionTest()
        {
            // Vertical Lines
            Line lv1 = new Line(new Point(2, 4), new Point(2, 10));
            Line lv2 = new Line(new Point(2, 7), new Point(2, 13));
            Point p = Intersection(lv1, lv2);
            Assert.NotNull(p);
            Assert.Equal(2, p.x);
            Assert.Equal(7, p.y);
        }

        [FactAttribute]
        public void HorizontalLinesIntersectionTest()
        {
            // Horizontal Lines
            Line lh1 = new Line(new Point(5, 5), new Point(3, 5));
            Line lh2 = new Line(new Point(3, 5), new Point(7, 5));
            Point p = Intersection(lh1, lh2);
            Assert.NotNull(p);
            Assert.Equal(3, p.x);
            Assert.Equal(5, p.y);

            lh1 = new Line(new Point(2, 15), new Point(9, 15));
            lh2 = new Line(new Point(9, 15), new Point(11, 15));
            p = Intersection(lh1, lh2);
            Assert.NotNull(p);
            Assert.Equal(9, p.x);
            Assert.Equal(15, p.y);
        }

        [FactAttribute]
        public void CrossingLinesIntersectionTest()
        {
            // Crossing Lines
            Line l1 = new Line(new Point(5, -2), new Point(1, -1));
            Line l2 = new Line(new Point(-2, -5), new Point(2, -1));
            Point p = Intersection(l1, l2);

            Assert.NotNull(p);
            Assert.Equal(1.8, p.x);
            Assert.Equal(-1.2, p.y);
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataIntersection.geLinesWithoutIntersection), MemberType = typeof(TestDataIntersection))]
        public void WithoutIntersectionTest(Line l1, Line l2)
        {
            Assert.Null(Intersection(l1, l2));
        }
    }

    class TestDataIntersection
    {
        public static TheoryData<Line, Line> geLinesWithoutIntersection()
        {
            // Vertical lines
            Line lv1 = new Line(new Point(2, 4), new Point(2, 10));
            Line lv2 = new Line(new Point(2, 10.2), new Point(2, 13));

            // Horizontal lines
            Line lh1 = new Line(new Point(8.5, 5), new Point(7.1, 5));
            Line lh2 = new Line(new Point(3, 5), new Point(7, 5));

            // Oblique lines
            Line lo1 = new Line(new Point(1, 5), new Point(4, 11));
            Line lo2 = new Line(new Point(1, 6.5), new Point(11, 31.5));

            // Parallel lines
            Line lpar1 = new Line(new Point(1, 5), new Point(1.5, 6));
            Line lpar2 = new Line(new Point(5, 14), new Point(-1, 2));

            return new TheoryData<Line, Line>() { { lv1, lv2 }, { lh1, lh2 }, { lo1, lo2 }, { lpar1, lpar2 } };
        }
    }
}