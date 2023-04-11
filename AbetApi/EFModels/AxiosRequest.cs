namespace AbetApi.EFModels
{
    public class AxiosRequest
    {
        public class Login
        {
            public string euid { get; set; }
            public string password { get; set; }
        }

        /// The following requests are using in <see cref="Role"/>
        public class CreateRole
        {
            public Role role { get; set; }
        }
        public class AddRoleToUser
        {
            public string EUID { get; set; }
            public string roleName { get; set; }
        }
        public class GetUsersByRole
        {
            public string roleName { get; set; }
        }
        public class DeleteRole
        {
            public string roleName { get; set; }
        }
        public class RemoveRoleFromUser
        {
            public string EUID { get; set; }
            public string roleName { get; set; }
        }
        public class EditUser
        {
            public string EUID { get; set; }
            public User NewUserInfo { get; set; }
        }
        public class DeleteUser
        {
            public string euid { get; set; }
        }
    }
}
