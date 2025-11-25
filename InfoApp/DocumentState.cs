using System.ComponentModel;

namespace InfoApp
{
    public enum DocumentState
    {
        [Description("Обрабатывается")]
        Processing = 1,

        [Description("Отправлен")]
        Sended = 2,

        [Description("Возвращён с ошибкой")]
        ReturnedWithError = 3,

        [Description("Успешно")]
        ReturnedWithOk = 4
    }
}
