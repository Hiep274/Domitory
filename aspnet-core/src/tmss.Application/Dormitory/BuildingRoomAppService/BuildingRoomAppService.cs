using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dormitory.IBuildingRoom;
using tmss.Dormitory.IBuildingRoom.Dto;
using tmss.Dormitory.IStudent.Dto;

namespace tmss.Dormitory.BuildingRoomAppService
{
    public class BuildingRoomAppService : tmssAppServiceBase, IBuidingRoomAppService
    {
        private readonly IDapperRepository<Building, long> _buildingRepo;
        private readonly IDapperRepository<Room, long> _roomRepo;
        private readonly IDapperRepository<Student, long> _studentRepo;
        public BuildingRoomAppService(
            IDapperRepository<Building, long> buildingRepo,
            IDapperRepository<Student, long> studentRepo,
            IDapperRepository<Room, long> roomRepo)
        {
            _buildingRepo = buildingRepo;
            _roomRepo = roomRepo;
            _studentRepo = studentRepo;
        }
        public async Task<List<BuildingForViewDto>> GetAllBuilding( )
        {
            IEnumerable<BuildingForViewDto> query = await _buildingRepo.QueryAsync<BuildingForViewDto>(@"
                Select Id ,Name, Description From Building where IsDeleted = 0");
            return query.ToList();
        }

        public async Task CreateOrEditBuilding(CreateOrEditBuildingDto input)
        {
            if (input.Id == null) await CreateBuilding(input);
            else await UpdateBuilding(input);
        }
        protected virtual async Task CreateBuilding(CreateOrEditBuildingDto input)
        {
            await _buildingRepo.QueryAsync<CreateOrEditBuildingDto>(@"
            Insert into Building (Name,Description,IsDeleted) Values (N'" + input.Name + "',N'" + input.Description + "',0)");
        }
        protected virtual async Task UpdateBuilding(CreateOrEditBuildingDto input)
        {
            await _buildingRepo.QueryAsync<CreateOrEditBuildingDto>(@"
            Update Building Set Name = N'" + input.Name + "', Description = N'" + input.Description + "' Where Id = '" + input.Id + "'  ");
        }

        public virtual async Task DeleteBuilding(EntityDto<long> input)
        {
            DateTime now = DateTime.Now;
            await _buildingRepo.QueryAsync(@"
            Update Building Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where Id = '" + input.Id + "'");
            await _roomRepo.QueryAsync(@"
            Update Room Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where BuildingId = '" + input.Id + "'");
        }

        public async Task<List<CreateOrEditBuildingDto>> GetBuildingForEdit(long? id)
        {
            IEnumerable<CreateOrEditBuildingDto> query =
                await _buildingRepo.QueryAsync<CreateOrEditBuildingDto>(@"
            Select Id, Name,Description from Building where  Id = '" + id + "'");
            return (List<CreateOrEditBuildingDto>)query;
        }

        public async Task<List<RoomForViewDto>> GetRoomByBuildingId(long? input)
        {
            IEnumerable<RoomForViewDto> query = await _roomRepo.QueryAsync<RoomForViewDto>(@"
                Select Id ,RoomNo, UnitPrice, Maxx, Amount From Room where IsDeleted = 0 And BuildingId ='"+input+"'");
            return query.ToList();
        }

        public async Task CreateOrEditRoom(CreateOrEditRoomDto input)
        {
            if (input.Id == null) await CreateRoom(input);
            else await UpdateRoom(input);
        }
        protected virtual async Task CreateRoom(CreateOrEditRoomDto input)
        {
            await _roomRepo.QueryAsync<CreateOrEditRoomDto>(@"
            Insert into Room (IsDeleted,BuildingId,RoomNo,UnitPrice,Maxx,Amount) Values (0,'" + input.BuildingId + "',N'" + input.RoomNo + "','"+input.UnitPrice+"','"+input.Maxx+"',0)");
        }
        protected virtual async Task UpdateRoom(CreateOrEditRoomDto input)
        {
            await _roomRepo.QueryAsync<CreateOrEditRoomDto>(@"
            Update Room Set RoomNo = N'" + input.RoomNo + "', UnitPrice = '" + input.UnitPrice + "', Maxx = '"+input.Maxx+"' Where Id = '" + input.Id + "'  ");
        }

        public virtual async Task DeleteRoom(EntityDto<long> input)
        {
            DateTime now = DateTime.Now;
            await _roomRepo.QueryAsync(@"
            Update Room Set IsDeleted = 1, DeletionTime ='" + now.ToString("yyyy/MM/dd ") + "' where Id = '" + input.Id + "'");
        }

        public async Task<List<CreateOrEditRoomDto>> GetRoomForEdit(long? id)
        {
            IEnumerable<CreateOrEditRoomDto> query =
                await _roomRepo.QueryAsync<CreateOrEditRoomDto>(@"
            Select Id, RoomNo,UnitPrice,Maxx,Amount from Room where  Id = '" + id + "'");
            return (List<CreateOrEditRoomDto>)query;
        }

        public async Task<List<StudentForViewDto>> GetListStudentInRoom(long? id)
        {
            string queryString = @"exec GetListStudentInRoom @RoomId = "+ id +" ";
            IEnumerable<StudentForViewDto> query =
                await _studentRepo.QueryAsync<StudentForViewDto>(queryString);
            return (List<StudentForViewDto>)query;
        }
        public async Task<List<BuildingForViewDto>> GetBuildingName()
        {
            IEnumerable<BuildingForViewDto> query = await _buildingRepo.QueryAsync<BuildingForViewDto>(@"
                Select Name From Building where IsDeleted = 0");
            return query.ToList();
        }
        public async Task<List<RoomForViewDto>> GetRoomNo()
        {
            IEnumerable<RoomForViewDto> query = await _buildingRepo.QueryAsync<RoomForViewDto>(@"
                Select RoomNo From Room where IsDeleted = 0");
            return query.ToList();
        }

    }
}
