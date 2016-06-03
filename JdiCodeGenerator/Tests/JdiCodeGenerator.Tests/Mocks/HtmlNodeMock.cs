namespace JdiCodeGenerator.Tests.Mocks
{
    using System.Xml.XPath;
    using HtmlAgilityPack;

    public class HtmlNodeMock : HtmlNode, IXPathNavigable
    {
        //
        // Summary:
        //     Gets a collection of flags that define specific behaviors for specific element
        //     nodes. The table contains a DictionaryEntry list with the lowercase tag name
        //     as the Key, and a combination of HtmlElementFlags as the Value.
        //public static Dictionary<string, HtmlElementFlag> ElementsFlags;
        ////
        //// Summary:
        ////     Gets the name of a comment node. It is actually defined as '#comment'.
        //public static readonly string HtmlNodeTypeNameComment;
        ////
        //// Summary:
        ////     Gets the name of the document node. It is actually defined as '#document'.
        //public static readonly string HtmlNodeTypeNameDocument;
        ////
        //// Summary:
        ////     Gets the name of a text node. It is actually defined as '#text'.
        //public static readonly string HtmlNodeTypeNameText;

        ////
        //// Summary:
        ////     Initializes HtmlNode, providing type, owner and where it exists in a collection
        ////
        //// Parameters:
        ////   type:
        ////
        ////   ownerdocument:
        ////
        ////   index:
        //public HtmlNode(HtmlNodeType type, HtmlDocument ownerdocument, int index);

        ////
        //// Summary:
        ////     Gets the collection of HTML attributes for this node. May not be null.
        //public HtmlAttributeCollection Attributes { get; }
        ////
        //// Summary:
        ////     Gets all the children of the node.
        //public HtmlNodeCollection ChildNodes { get; }
        ////
        //// Summary:
        ////     Gets a value indicating if this node has been closed or not.
        //public bool Closed { get; }
        ////
        //// Summary:
        ////     Gets the collection of HTML attributes for the closing tag. May not be null.
        //public HtmlAttributeCollection ClosingAttributes { get; }
        ////
        //// Summary:
        ////     Gets the first child of the node.
        //public HtmlNode FirstChild { get; }
        ////
        //// Summary:
        ////     Gets a value indicating whether the current node has any attributes.
        //public bool HasAttributes { get; }
        ////
        //// Summary:
        ////     Gets a value indicating whether this node has any child nodes.
        //public bool HasChildNodes { get; }
        ////
        //// Summary:
        ////     Gets a value indicating whether the current node has any attributes on the closing
        ////     tag.
        //public bool HasClosingAttributes { get; }
        ////
        //// Summary:
        ////     Gets or sets the value of the 'id' HTML attribute. The document must have been
        ////     parsed using the OptionUseIdAttribute set to true.
        //public string Id { get; set; }
        ////
        //// Summary:
        ////     Gets or Sets the HTML between the start and end tags of the object.
        //public virtual string InnerHtml { get; set; }
        ////
        //// Summary:
        ////     Gets or Sets the text between the start and end tags of the object.
        //public virtual string InnerText { get; }
        ////
        //// Summary:
        ////     Gets the last child of the node.
        //public HtmlNode LastChild { get; }
        ////
        //// Summary:
        ////     Gets the line number of this node in the document.
        //public int Line { get; }
        ////
        //// Summary:
        ////     Gets the column number of this node in the document.
        //public int LinePosition { get; }
        ////
        //// Summary:
        ////     Gets or sets this node's name.
        //public string Name { get; set; }
        ////
        //// Summary:
        ////     Gets the HTML node immediately following this element.
        //public HtmlNode NextSibling { get; }
        ////
        //// Summary:
        ////     Gets the type of this node.
        //public HtmlNodeType NodeType { get; }
        ////
        //// Summary:
        ////     The original unaltered name of the tag
        public virtual string OriginalName { get; set; }

        public XPathNavigator CreateNavigator()
        {
            return null;
        }

        public HtmlNodeMock(HtmlNodeType type, HtmlDocument ownerdocument, int index) : base(type, ownerdocument, index)
        {
        }

        //public HtmlNodeMock()
        //{
            
        //}
    }
}