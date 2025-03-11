using LHJ.IRepository;
using LHJ.IRepository.ManagerRepository;
using LHJ.IService.IServices;
using LHJ.SqlSugarCore.Entities;
using LHJ.SqlSugarCore.Model;
using SqlSugar;

namespace LHJ.Service.Services;

public class HuHuLogService : BaseService<HuHuLog>, IHuHuLogService
{
    IBaseRepository<HuHuLog> _baseRepository;
    public HuHuLogService(IBaseRepository<HuHuLog> baseRepository) : base(baseRepository)
    {
        _baseRepository = baseRepository;
    }

}
