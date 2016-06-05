namespace JdiCodeGenerator.Core.ObjectModel
{
    using System.Collections.Generic;
    using Abstract;

    public class Rule : IRule
    {
        public IEnumerable<IRuleCondition> Conditions { get; set; }
        public HtmlElementTypes SourceType { get; set; }
        public JdiElementTypes TargetType { get; set; }

        public Rule()
        {
            Conditions = new List<IRuleCondition>();
        }
    }
}
