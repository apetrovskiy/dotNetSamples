namespace testCastleCoreWithAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class MyPropertyAttribute : Attribute
    {
        public string RowPosition { get; set; }
        public string ColumnHeading { get; set; }

        public MyPropertyAttribute(string rowPosition, string columnHeading)
        {
            this.RowPosition = rowPosition;
            this.ColumnHeading = columnHeading;
        }
    }
}