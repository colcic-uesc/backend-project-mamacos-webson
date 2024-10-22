using UescColcicAPI.Core;
using UescColcicAPI.Services.BD;
using System.Threading.Tasks;

namespace UescColcicAPI.Services.BD;

public class RequestLogService : IBaseLog
{
    private readonly UescColcicDBContext _context;

    public RequestLogService(UescColcicDBContext context)
    {
        _context = context;
    }

    public async Task LogRequestAsync(RequestLog requestLog)
    {
        await _context.RequestLogs.AddAsync(requestLog);
        await _context.SaveChangesAsync();
    }
}
