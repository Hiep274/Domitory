using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmss.Dormitory.IInBill;
using tmss.Dormitory.IInBill.Dto;
using tmss.Dormitory.IInvoice.Dto;

namespace tmss.Dormitory.InBillAppService
{
    public class InBillAppService : tmssAppServiceBase, IInBillAppService
    {
        private readonly IDapperRepository<Room, long> _roomRepo;
        private readonly IDapperRepository<InBill, long> _inBillRepo;

        public InBillAppService(IDapperRepository<InBill, long> inBillRepo,
            IDapperRepository<Room, long> roomRepo)
        {
            _roomRepo = roomRepo;
            _inBillRepo = inBillRepo;

        }

        public async Task<List<InBillForViewDto>> GetAll(InBillInputDto input)
        {
            string queryString = @"exec GetAllOrFilterInBill @RoomId = " + (input.RoomId == null ? "null" : input.RoomId.ToString()) + ",@StartDate = '" + input.StartDate.Value.ToString("yyyy/MM/dd") + "',@EndDate = '" + input.EndDate.Value.ToString("yyyy/MM/dd") + "', @IsPaid = " + (input.IsPaid == null ? "null" : input.IsPaid.ToString()) + " ";
            IEnumerable<InBillForViewDto> query = await _inBillRepo.QueryAsync<InBillForViewDto>(queryString);
            return query.ToList();
        }

        public async Task CreateOrEdit(CreateOrEditInBillDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        protected virtual async Task Create(CreateOrEditInBillDto input)
        {
            DateTime now = DateTime.Now;

            await _inBillRepo.QueryAsync<CreateOrEditInBillDto>(@"
            Insert into InBill (IsDeleted,RoomId,Cost,Date,Reason,IsPaid) Values (0,'" + input.RoomId + "','" + input.Cost + "','" + now.ToString("yyyy/MM/dd") + "',N'" + input.Reason + "',0)");
        }
        protected virtual async Task Update(CreateOrEditInBillDto input)
        {
            await _inBillRepo.QueryAsync<CreateOrEditInBillDto>(@"
            Update InBill Set Cost = '" + input.Cost + "', Reason = N'" + input.Reason + "', Ispaid= '" + input.IsPaid + "' Where Id = '" + input.Id + "'  ");
        }

        public virtual async Task Delete(EntityDto<long> input)
        {
            DateTime now = DateTime.Now;
            await _inBillRepo.QueryAsync(@"
            Update InBill Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where Id = '" + input.Id + "'");
        }

        public async Task<List<CreateOrEditInBillDto>> GetInBillForEdit(long? id)
        {
            IEnumerable<CreateOrEditInBillDto> query =
                await _inBillRepo.QueryAsync<CreateOrEditInBillDto>(@"
            Select Id, RoomId,Cost,Date,Reason,IsPaid from InBill where IsDeleted = 0 and Id = '" + id + "'");
            return (List<CreateOrEditInBillDto>)query;
        }

        public async Task<List<ListRoomDto>> GetListRoom()
        {
            IEnumerable<ListRoomDto> query = await _roomRepo.QueryAsync<ListRoomDto>(@"
                Select Id,RoomNo from Room where IsDeleted = 0 ");
            return query.ToList();
        }
        public async Task<List<InBIllForDashboardDto>> GetInBillForDashboard(DateTime? input)
        {
            string queryString = @"exec GetInBillForDashboard @Date = '" + input.Value.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<InBIllForDashboardDto> query = await _inBillRepo.QueryAsync<InBIllForDashboardDto>(queryString);
            return query.ToList();
        }
    }
}
