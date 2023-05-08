using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Linq.Extensions;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dormitory.IStudent;
using tmss.Dormitory.IStudent.Dto;

namespace tmss.Dormitory.StudentAppService
{
    public class StudentAppService: tmssAppServiceBase, IStudentAppService
    {
        private readonly IDapperRepository<Student, long> _studentRepo;
        public StudentAppService( IDapperRepository<Student,long> studentRepo)
        {
            _studentRepo = studentRepo;

        }

        public async Task<List<StudentForViewDto>> GetAll(StudentInputDto input)
        {
            
            IEnumerable<StudentForViewDto> query = await _studentRepo.QueryAsync<StudentForViewDto>(@"
                EXEC GetAllOrFilterStudent
                @Name=@Name,@Gender=@Gender,@StudentNo=@StudentNo,@Cmnd = @Cmnd,@Phone=@Phone,@IsRoom=@IsRoom",
                new {Name=input.Name,Gender=input.Gender,StudentNo=input.StudentNo,Cmnd=input.Cmnd,Phone=input.Phone,IsRoom=input.IsRoom });
            return query.ToList();
        }

        public async Task CreateOrEdit(CreateOrEditStudentDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        protected virtual async Task Create(CreateOrEditStudentDto input)
        {   
            await _studentRepo.QueryAsync<CreateOrEditStudentDto>(@"
            Insert into Student (IsDeleted,Name,Gender,StudentNo,Cmnd,Phone,IsRoom) Values (0,N'" + input.Name + "','"+input.Gender+"','" + input.StudentNo + "','" + input.Cmnd + "','" + input.Phone + "',0)");
        }
        protected virtual async Task Update(CreateOrEditStudentDto input)
        {
            await _studentRepo.QueryAsync<CreateOrEditStudentDto>(@"
            Update Student Set Name = N'"+input.Name+"', StudentNo = '"+input.StudentNo+"', Gender= '"+input.Gender+"',Cmnd = '"+input.Cmnd+"',Phone = '"+input.Phone+"', IsRoom = '"+input.IsRoom+"' Where Id = '"+input.Id+"'  ");
        }

        public virtual async Task Delete(EntityDto<long>  input)
        {
            DateTime now = DateTime.Now;
            await _studentRepo.QueryAsync(@"
            Update Student Set IsDeleted = 1, DeletionTime ='"+now.ToString("yyyy/MM/dd ")+"' where Id = '"+input.Id+"'");
        }

        public async Task<List<CreateOrEditStudentDto>> GetStudentForEdit(long? id)
        {
            IEnumerable<CreateOrEditStudentDto> query = 
                await _studentRepo.QueryAsync<CreateOrEditStudentDto>(@"
            Select Id, Name,StudentNo,Gender,Cmnd,Phone,IsRoom from Student where IsDeleted = 0 and Id = '"+id+"'");
            return (List<CreateOrEditStudentDto>)query;
        }
        //public async Task<List<StudentForViewDto>> SearchStudent()
        //{
        //    IEnumerable<StudentForViewDto> query = await _studentRepo.QueryAsync<StudentForViewDto>(@"
        //    Select Id, Name,StudentNo,Gender,Cmnd,Phone,IsRoom from Student where IsDeleted = 0 ");
        //    return query.ToList();
        //}
        public async Task<List<StudentForViewDto>> GetListStudentNo()
        {
            IEnumerable<StudentForViewDto> query = await _studentRepo.QueryAsync<StudentForViewDto>(@"
            Select StudentNo,Cmnd from Student where IsDeleted = 0 ");
            return query.ToList();
        }
    }
}
