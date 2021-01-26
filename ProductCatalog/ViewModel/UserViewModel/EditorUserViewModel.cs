using Flunt.Notifications;
using Flunt.Validations;

namespace ProductCatalog.ViewModel.UserViewModel
{
    public class EditorUserViewModel : Notifiable, IValidatable
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(UserName, 65,"Name", "Não é possivel cadastrar um nome com mais de 60 caracteres")
                .HasMinLen(UserName, 3, "Name", "Não é possivel cadastrar um nome com menos de 3 caracteres")
                .HasMaxLen(Email, 120, "Email", "Não é possivel cadastrar um email com mais de 120 caracteres"));
        }
    }
}
