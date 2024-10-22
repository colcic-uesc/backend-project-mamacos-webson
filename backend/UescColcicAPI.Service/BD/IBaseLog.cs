using UescColcicAPI.Core;
public interface IBaseLog
{
    Task LogRequestAsync(RequestLog requestLog);
}