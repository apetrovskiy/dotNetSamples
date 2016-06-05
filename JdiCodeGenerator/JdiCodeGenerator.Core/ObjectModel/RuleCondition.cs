namespace JdiCodeGenerator.Core.ObjectModel
{
    using System;
    using Abstract;

    public class RuleCondition : IRuleCondition
    {
        public Markers Marker { get; set; }
        public string MarkerValue { get; set; }
        public NodeRelationships Relationship { get; set; }
    }
}
