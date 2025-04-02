namespace session26_validation_component_razor.Services
{
    public class UserService
    {
        public event Action? Onchanged;
        private string currentUser;

        public string CurrentUser
        {
            get { return currentUser; }

        }

        public void Login(string username)
        {
            currentUser = username;
            NotifyStateChanged();
        }

        public void Logout()
        {
            currentUser = string.Empty;
            NotifyStateChanged();
        }

        //function check user already login
        public bool IsAuthenticate()
        {
            return !string.IsNullOrEmpty(currentUser);
        }

        private void NotifyStateChanged()
        {
            if (Onchanged != null)
                Onchanged.Invoke(); //inform to blazor know data was changed
        }
    }
}
