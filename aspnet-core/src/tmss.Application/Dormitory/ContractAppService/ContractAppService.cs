using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dormitory.IContract;
using tmss.Dormitory.IContract.Dto;
using tmss.Dormitory.IInvoice.Dto;

namespace tmss.Dormitory.ContractAppService
{
    public class ContractAppService : tmssAppServiceBase, IContractAppService
    {
        private readonly IDapperRepository<Contract, long> _contractRepo;
        private readonly IDapperRepository<Room, long> _roomRepo;
        private readonly IDapperRepository<Student, long> _studentRepo;

        public ContractAppService(IDapperRepository<Contract, long> contractRepo,
            IDapperRepository<Room, long> roomRepo, IDapperRepository<Student, long> studentRepo)
        {
            _contractRepo = contractRepo;
            _roomRepo = roomRepo;
            _studentRepo = studentRepo;
        }

        public async Task<List<ContractForViewDto>> GetAll(ContractInputDto input)
        {
            string queryString = @"exec GetAllOrFilterContract @RoomId = " + (input.RoomId == null ? "null" : input.RoomId.ToString()) + ",@StartDate = '" + input.StartDate.Value.ToString("yyyy/MM/dd") + "',@EndDate = '" + input.EndDate.Value.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<ContractForViewDto> query = await _contractRepo.QueryAsync<ContractForViewDto>(queryString);
            return query.ToList();
        }
        public async Task CreateOrEdit(CreateOrEditContractDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        protected virtual async Task Create(CreateOrEditContractDto input)
        {
            DateTime now = DateTime.Now;
            var Contract = "HĐ"+now.ToString("yyyyMMddHHmmss");

            await _contractRepo.QueryAsync<CreateOrEditContractDto>(@"
            insert into Contract(IsDeleted,ContractNo,StudentId,RoomId,ContractDate,StartDate,EndDate)
            values (0,'"+ Contract + "','"+input.StudentId+"','"+input.RoomId+"','"+now.ToString("yyyy/MM/dd")+"','"+input.StartDate.ToString("yyyy/MM/dd")+"','"+input.EndDate.ToString("yyyy/MM/dd") + "')");
        }
        protected virtual async Task Update(CreateOrEditContractDto input)
        {
            await _contractRepo.QueryAsync<CreateOrEditContractDto>(@"
            Update Contract Set RoomId = '" + input.RoomId + "', StartDate = '" + input.StartDate.ToString("yyyy/MM/dd") + "', EndDate= '" + input.EndDate.ToString("yyyy/MM/dd") + "' Where Id = '" + input.Id + "'  ");
        }

        public virtual async Task Delete(EntityDto<long> input)
        {
            DateTime now = DateTime.Now;
            await _contractRepo.QueryAsync(@"
            Update Contract Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where Id = '" + input.Id + "'");
        }
        
        public async Task<List<CreateOrEditContractDto>> GetContractForEdit(long? id)
        {
            IEnumerable<CreateOrEditContractDto> query =
                await _contractRepo.QueryAsync<CreateOrEditContractDto>(@"
            Select Id, ContractNo,StudentId,RoomId,ContractDate,StartDate,EndDate from Contract where IsDeleted = 0 and Id = '" + id + "'");
            return (List<CreateOrEditContractDto>)query;
        }
        
        public async Task<List<ListRoomDto>> GetListRoomForCreate(long input)
        {
            string queryString = @"exec GetListRoomForConTract @StudentId = "+input+"  ";
            IEnumerable<ListRoomDto> query = await _roomRepo.QueryAsync<ListRoomDto>(queryString);
            return query.ToList();
        }
        public async Task<List<ListRoomDto>> GetListRoom()
        {
            IEnumerable<ListRoomDto> query = await _roomRepo.QueryAsync<ListRoomDto>(@"
                Select Id,RoomNo,UnitPrice from Room where IsDeleted = 0 ");
            return query.ToList();
        }
        public async Task<List<ListStudentDto>> GetListStudentForCreate()
        {
            IEnumerable<ListStudentDto> query = await _studentRepo.QueryAsync<ListStudentDto>(@"
                Select Id,Name,StudentNo from Student where IsDeleted = 0 And IsRoom=0");
            return query.ToList();
        }
        public async Task<List<ListStudentDto>> GetListStudent()
        {
            IEnumerable<ListStudentDto> query = await _studentRepo.QueryAsync<ListStudentDto>(@"
                Select Id,Name,StudentNo from Student where IsDeleted = 0");
            return query.ToList();
        }
        public async Task<List<ContractForDashboard>> GetTotalContractForDashboard(DateTime? input)
        {
            string queryString = @"exec GetContractForDashboard @Date = '" + input.Value.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<ContractForDashboard> query = await _contractRepo.QueryAsync<ContractForDashboard>(queryString);
            return query.ToList();
        }
        public async Task<List<ContractForDashboard>> GetTotalContractMoneyForDashboard(DateTime? input)
        {
            string queryString = @"exec GetTotalMoneyContract @Date = '" + input.Value.ToString("yyyy/MM/dd") + "' ";
            IEnumerable<ContractForDashboard> query = await _contractRepo.QueryAsync<ContractForDashboard>(queryString);
            return query.ToList();
        }
    }
}
