namespace JdiCodeGenerator.Core.ObjectModel.Abstract
{
    public interface IRuleCondition
    {
        NodeRelationships Relationship { get; set; }
        Markers Marker { get; set; }
        string MarkerValue { get; set; }
    }
}