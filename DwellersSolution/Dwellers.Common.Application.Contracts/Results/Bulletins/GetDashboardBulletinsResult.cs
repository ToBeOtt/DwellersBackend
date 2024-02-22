namespace Dwellers.Common.Application.Contracts.Results.Bulletins
{
    public class DashboardBulletins
    {
        public string? BulletinTitle { get; set; }
        public string? Author { get; set; }
        public string? BulletinText { get; set; }
        public string? BulletinScope { get; set; }

        public string? DatePublished { get; set; }
        public string? DateModified { get; set; }

        public DashboardBulletins(string? bulletinTitle, 
            string? author, string? bulletinText, 
            string? bulletinScope, 
            string? datePublished, 
            string? dateModified)
        {
            BulletinTitle = bulletinTitle;
            Author = author;
            BulletinText = bulletinText;
            BulletinScope = bulletinScope;
            DatePublished = datePublished;
            DateModified = dateModified;
        }
    }
    public record GetDashboardBulletinsResult (
        List<DashboardBulletins> ListOfBulletinsForDashboard);
}
