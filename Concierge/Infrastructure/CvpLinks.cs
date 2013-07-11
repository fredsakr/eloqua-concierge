namespace Concierge.Infrastructure
{
    public class CvpLinks
    {
        public string ContactActivityLink =
            "http://login.eloqua.com/autoLogin?LoginPrefix=ORSE&Url=FlexReports%2fDisplayReport2.aspx%3fStandardReportID%3d1297%2526EmailAddress%3d%7b%21Contact_Email%7d%2526ShowPrintOption%3dTrue";

        public string EmailUnsubscribeLink =
            "https://qasecure.eloquacorp.com/cvp.aspx?LP=ORSE&elqExtUserName=Fred.S&URL=EmailUnsubscribeByAddressAsAgent.aspx?elqEmailAddress={!Contact.Email}";

        public string SendEmailLink =
            "https://secure.eloqua.com/cvp.aspx?LP=ORSE&URL=Agent/email/CampaignControl2.aspx?EmailAddress={!Contact.Email}";
    }
}