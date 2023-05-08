using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dormitory.IOutBill;
using tmss.Dormitory.IOutBill.Dto;

namespace tmss.Dormitory.OutBillAppService
{
    public class OutBillAppService : tmssAppServiceBase, IOutBillAppService
    {
        private readonly IDapperRepository<OutBill, long> _outBillRepo;

        public OutBillAppService(IDapperRepository<OutBill, long> outBillRepo)
        {
            _outBillRepo = outBillRepo;
        }

        public async Task<List<OutBillForViewDto>> GetAll(OutBillInput input)
        {
            string queryString = @"exec GetAllOrFilterOutBill @StartDate = '" + input.StartDate.Value.ToString("yyyy/MM/dd") + "',@EndDate = '" + input.EndDate.Value.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<OutBillForViewDto> query = await _outBillRepo.QueryAsync<OutBillForViewDto>(queryString);
            return query.ToList();
        }

        public async Task CreateOrEdit(CreateOrEditOutBillDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        protected virtual async Task Create(CreateOrEditOutBillDto input)
        {
            DateTime now = DateTime.Now;

            await _outBillRepo.QueryAsync<CreateOrEditOutBillDto>(@"
            Insert into OutBill (IsDeleted,Cost,Date,Description) Values (0,'" + input.Cost + "','" + now.ToString("yyyy/MM/dd") + "',N'" + input.Description + "')");
        }
        protected virtual async Task Update(CreateOrEditOutBillDto input)
        {
            await _outBillRepo.QueryAsync<CreateOrEditOutBillDto>(@"
            Update OutBill Set Cost = '" + input.Cost + "', Description = N'" + input.Description + "' Where Id = '" + input.Id + "'  ");
        }

        public virtual async Task Delete(EntityDto<long> input)
        {
            DateTime now = DateTime.Now;
            await _outBillRepo.QueryAsync(@"
            Update OutBill Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where Id = '" + input.Id + "'");
        }

        public async Task<List<CreateOrEditOutBillDto>> GetOutBillForEdit(long? id)
        {
            IEnumerable<CreateOrEditOutBillDto> query =
                await _outBillRepo.QueryAsync<CreateOrEditOutBillDto>(@"
            Select Id,Cost,Date,Description from OutBill where IsDeleted = 0 and Id = '" + id + "'");
            return (List<CreateOrEditOutBillDto>)query;
        }
        public async Task<List<OutBillForDashboardDto>> GetOutBillForDashboard(DateTime input)
        {
            string queryString = @"exec GetOutBillForDashboard @Date = '" + input.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<OutBillForDashboardDto> query = await _outBillRepo.QueryAsync<OutBillForDashboardDto>(queryString);
            return query.ToList();
        }
    }
}
