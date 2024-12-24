using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Interfaces;
public interface IMediasService
{
    Task<Response<string>> MigrateMedia(MigrateModel model);
}
