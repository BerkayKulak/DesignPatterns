using System.Text;

namespace WebApp.Template.UserCards
{
    public class PrimeUserCardTemplate:UserCardTemplate
    {
        protected override string SetFooter()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<a href='#' class='card-link'>Mesaj Gönder</a>");
            stringBuilder.Append("<a href='#' class='card-link'>Detaylı Profil</a>");
            return stringBuilder.ToString();
        }

        protected override string SetPicture()
        {
            return $"<img class='card-img-top' src='{AppUser.PictureUrl}' >";
        }
    }
}
