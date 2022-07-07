namespace APIPetSitting.Models.Concretes.Users.Updates
{
    public class Email
    {
        public string FromSenderEmail { get; set; }
        public string FromSenderName { get; set; }
        public string ToRecipientEmail { get; set; }
        public string ToRecipientName { get; set; }
        public string Subject { get; set; }
        public string PlainText { get; set; }
        public string HtmlText { get; set; }
    }
}
