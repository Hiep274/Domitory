using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dormitory.IBuildingRoom.Dto;
using tmss.Dormitory.IInvoice;
using tmss.Dormitory.IInvoice.Dto;

namespace tmss.Dormitory.InvoiceAppService
{
    public class InvoiceAppService : tmssAppServiceBase, IInvoiceAppService
    {
        private readonly IDapperRepository<Invoice, long> _invoiceRepo;
        private readonly IDapperRepository<Room, long> _roomRepo;
        public InvoiceAppService(IDapperRepository<Invoice, long> invoiceRepo,
            IDapperRepository<Room, long> roomRepo)
        {
            _invoiceRepo = invoiceRepo;
            _roomRepo = roomRepo;
        }

        public async Task<List<InvoiceForViewDto>> GetAll(InvoiceInputDto input)
        {
            string queryString = @"exec GetAllOrFilterInvoice @RoomId = " + (input.RoomId == null ? "null" : input.RoomId.ToString()) + ",@StartDate = '" + input.StartDate.Value.ToString("yyyy/MM/dd") + "',@EndDate = '" + input.EndDate.Value.ToString("yyyy/MM/dd") + "', @IsPaid = " + (input.IsPaid == null ? "null" : input.IsPaid.ToString()) + " ";
            IEnumerable<InvoiceForViewDto> query = await _invoiceRepo.QueryAsync<InvoiceForViewDto>(queryString);
            return query.ToList();
        }

        public async Task CreateOrEdit(CreateOrEditInvoiceDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        protected virtual async Task Create(CreateOrEditInvoiceDto input)
        {
            DateTime now = DateTime.Now;
            await _invoiceRepo.QueryAsync<CreateOrEditInvoiceDto>(@"
            Insert into Invoice (IsDeleted,RoomId,ElecOld,ElecNew,WarOld,WarNew,ElecUnit,WarUnit,Month,IsPaid) Values (0,'" + input.RoomId + "','" + input.ElecOld + "','" + input.ElecNew + "','" + input.WarOld + "','" + input.WarNew + "','"+input.ElecUnit+"','"+input.WarUnit+"','"+now.ToString("yyyy/MM/dd")+"',0)");
        }
        protected virtual async Task Update(CreateOrEditInvoiceDto input)
        {
            await _invoiceRepo.QueryAsync<CreateOrEditInvoiceDto>(@"
            Update Invoice Set ElecOld = '" + input.ElecOld + "', ElecNew = '" + input.ElecNew + "', WarOld= '" + input.WarOld + "',WarNew = '" + input.WarNew + "',ElecUnit = '" + input.ElecUnit + "', WarUnit = '" + input.WarUnit + "', IsPaid = '"+input.IsPaid+"' Where Id = '" + input.Id + "'  ");
        }

        public virtual async Task Delete(EntityDto<long> input)
        {
            DateTime now = DateTime.Now;
            await _invoiceRepo.QueryAsync(@"
            Update Invoice Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where Id = '" + input.Id + "'");
        }

        public async Task<List<CreateOrEditInvoiceDto>> GetInvoiceForEdit(long? id)
        {
            IEnumerable<CreateOrEditInvoiceDto> query =
                await _invoiceRepo.QueryAsync<CreateOrEditInvoiceDto>(@"
            Select * from Invoice where IsDeleted = 0 and Id = '" + id + "'");
            return (List<CreateOrEditInvoiceDto>)query;
        }
 
        public async Task<List<ListRoomDto>> GetListRoom()
        {
            IEnumerable<ListRoomDto> query = await _roomRepo.QueryAsync<ListRoomDto>(@"
                Select Id,RoomNo from Room where IsDeleted = 0 ");
            return query.ToList();
        }
        public async Task<List<ListRoomDto>> GetListRoomForCreate()
        {
            IEnumerable<ListRoomDto> query = await _roomRepo.QueryAsync<ListRoomDto>(@"
                exec GetListRoomForCreateInvoice ");
            return query.ToList();
        }
        public async Task<List<InvoiceForDashboasdDto>> GetInvoiceForDashboard(DateTime input)
        {
            string queryString = @"exec GetInvoiceForDashboard @Date = '" + input.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<InvoiceForDashboasdDto> query = await _invoiceRepo.QueryAsync<InvoiceForDashboasdDto>(queryString);
            return query.ToList();
        }
        public async Task<List<InvoiceForViewDto>> GetLastMonthInvoice(long input)
        {
            string queryString = @"select * from Invoice where RoomId='" + input + "' AND (( MONTH(Month) = MONTH(GetDate())-1 AND YEAR(Month)=YEAR(GETDATE())) OR (MONTH(GETDATE())=1 AND YEAR(Month)=YEAR(GETDATE())-1) AND MONTH(Month)=12) AND IsDeleted = 0";
;
            IEnumerable<InvoiceForViewDto> query = await _invoiceRepo.QueryAsync<InvoiceForViewDto>(queryString);
            return query.ToList();
        }
    }
}

