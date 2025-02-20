using LHJ.IRepository;
using LHJ.IService.IServices;
using LHJ.SqlSugarCore.Entities;
using LHJ.SqlSugarCore.Model;
using SqlSugar;

namespace LHJ.Service.Services;

public class TrainPlanService : BaseService<TrainPlan>, ITrainPlanService
{
    IBaseRepository<TrainPlan> _baseRepository;
    //这里我们要把实参传到baseService 不然会报错
    public TrainPlanService(IBaseRepository<TrainPlan> baseRepository) : base(baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public Task<ResponsePage<List<TrainPlanDto<List<TrainPlanDetail>>>>> GetTrainPlans(RequestData data)
    {
        ResponsePage<List<TrainPlanDto<List<TrainPlanDetail>>>> responsePage = new();

        int totalNumber = 0;

        responsePage.data = _baseRepository.GetDb().Queryable<TrainPlan, LoginUser>((a, c) => new object[] {
            JoinType.Inner, c.UserID == a.CreateID
        }
        ).Where(a => a.CompanyID == data.companyId).Select((a, c) => new TrainPlanDto<List<TrainPlanDetail>>()
        {
            id = a.Id,
            code = a.Code,
            companyId = a.CompanyID,
            createID = a.CreateID,
            createName = c.UserName,
            createTime = a.CreateTime,
            billState = a.BillState
        }).ToPageList(data.page.pageNumber, data.page.pageSize, ref totalNumber);

        if (totalNumber > 0)
        {
            List<int> ids = responsePage.data.Select(s => s.id).ToList();

            List<TrainPlanDetail> details = _baseRepository.GetDb().Queryable<TrainPlanDetail>().Where(s => ids.Contains(s.Id)).ToList();

            foreach (var item in responsePage.data)
            {
                item.details = details.Where(s => s.Id == item.id).ToList();
            }
        }

        responsePage.totalNumber = totalNumber;

        return Task.FromResult(responsePage);
    }
}
