namespace Aferback.WebAPI.Application.Helpers.Http
{
    public interface IResponse
    {
        object Data { get; set; }
        object ErrorMessage { get; set; }
        bool IsSuccess { get; set; }
        string Remark { get; set; }
    }
}