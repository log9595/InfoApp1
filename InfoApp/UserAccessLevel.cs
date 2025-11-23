using System.ComponentModel;

namespace InfoApp
{
    public enum UserAccessLevel
    {
        [Description("Администратор")]
        Administrator = 0,

        [Description("Чтение/Редактирование")]
        ReadWrite = 1,

        [Description("Чтение")]
        Read = 2
    }
}
