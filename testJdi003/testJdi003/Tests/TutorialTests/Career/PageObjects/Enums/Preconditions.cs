namespace testJdi003.Tests.TutorialTests.Career.PageObjects.Enums
{
    public class Preconditions : WebPreconditions
    {
        public static readonly Preconditions HOME_PAGE = new Preconditions("");

        private Preconditions(string uri)
        {
            //this(()->WebPreconditions.checkUrl(uri), ()->WebPreconditions.openUri(uri));
        }

        public bool checkAction()
        {
            //checkAction.get();
            return false;
        }

        public void moveToAction()
        {
            //throw new NotImplementedException();
        }
    }
}
