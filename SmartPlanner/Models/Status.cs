namespace SmartPlanner.Models
{
    public enum Status
    {
        Pending = 1,            //В ожидании
        Planned = 2,            //В плане
        InProgress = 3,         //В работе
        InTesting = 4,          //В тестировании
        Done = 5,               //Выполнено
        Postponed = 6,          //Отложена
        Canceled = 7,           //Отменена
    }
}