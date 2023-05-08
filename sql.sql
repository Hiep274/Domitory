	
	--Store for Get list student 
		ALTER PROCEDURE [dbo].[GetAllOrFilterStudent]
			@Name nvarchar(255),
			@Gender int,
			@StudentNo nvarchar(64),
			@Cmnd nvarchar(64),
			@Phone nvarchar(64),
			@IsRoom bit
			As
			Select Id, Name,StudentNo,Gender,Cmnd,Phone,IsRoom From Student
			Where IsDeleted=0 and (@Name IS null or Name like '%'+@Name+'%') and (@StudentNo is null Or StudentNo like '%'+@StudentNo+'%')
			and (@Gender is null or Gender = @Gender)
			and (@Cmnd is null or Cmnd like '%'+@Cmnd+'%')
			and (@Phone is null or Phone like '%'+@Phone+'%') 
			and (@IsRoom is null or IsRoom = @IsRoom)

	--Trigger update Amount of Room and Status of Student when insert contract
		ALTER trigger trg_contract On CONTRACT after 
			insert 
			as begin
			Declare @a int = (Select StudentId from inserted)
			Declare @RoomId int = (Select RoomId from inserted)
			update room set Amount = (Select Count(Id) from Contract where IsDeleted =0 and RoomId = @RoomId AND EndDate>=GETDATE()) where Id = @RoomId
			update Student 
			set IsRoom = 1 where Student.Id = @a
			END
		go
	-- trigger update Amount of Room and Status of Student when update of delete contract
		ALTER trigger trg_contract_delete On Contract after 
			update 
			as begin 
			Declare @dele bit = (Select IsDeleted from inserted)
			Declare @a int = (Select StudentId from deleted)
			Declare @RoomId int = (Select RoomId from deleted)
			update room set Amount = (Select Count(Id) from Contract where IsDeleted =0 and RoomId = @RoomId) where Id = @RoomId
			if(@dele = 1)
			begin
			update Student
			set IsRoom = 0 where Student.Id = @a
			end
			else
			begin 
			update Student 
			set IsRoom = 1 where Student.Id = @a
			end
		end

	--Store get list Invoice
		ALTER Procedure [dbo].[GetAllOrFilterInvoice]
			@RoomId int,
			@StartDate nvarchar(50),
			@EndDate nvarchar(50),
			@IsPaid bit
			As
			Select Invoice.Id AS Id,RoomId,Room.RoomNo As RoomNo, ElecOld,ElecNew,WarOld,WarNew,ElecUnit,WarUnit,Month,IsPaid 
			from Invoice inner join Room on Room.Id = Invoice.RoomId  where Invoice.IsDeleted = 0 and
			(@RoomId IS null or RoomId = @RoomId) and (Invoice.Month between @StartDate and @EndDate )
			and (@IsPaid is null or IsPaid = @IsPaid)

	--Store get list InBill
		ALTER Procedure [dbo].[GetAllOrFilterInBill]
			@RoomId int,
			@StartDate nvarchar(50),
			@EndDate nvarchar(50),
			@IsPaid bit
			As
			select InBill.Id,RoomNo,Cost,Date,Reason,IsPaid from InBill
			inner join Room on Room.Id=InBill.RoomId
			where InBill.IsDeleted =0 and Room.IsDeleted=0 and
			(@RoomId Is null or RoomId = @RoomId) and (InBill.Date between @StartDate and @EndDate )
			and (@IsPaid is null or IsPaid = @IsPaid)

	--Store get list OutBill
		ALTER Procedure [dbo].[GetAllOrFilterOutBill]
			@StartDate nvarchar(50),
			@EndDate nvarchar(50)
			As
			select Id,Cost,Date,Description from OutBill
			where IsDeleted =0 and 
			(Date between @StartDate and @EndDate)

	--Store get list Contract
		ALTER Procedure [dbo].[GetAllOrFilterContract]
			@RoomId int,
			@StartDate nvarchar(50),
			@EndDate nvarchar(50)
			As
			 select Contract.Id,ContractNo,StudentNo,Student.Name As StudentName,Gender,
						Phone,RoomNo,UnitPrice,ContractDate,StartDate,EndDate
						from Contract 
						inner join Student on Student.Id = Contract.StudentId
						inner join Room on Room.Id = Contract.RoomId
						where Contract.IsDeleted = 0 and
			(@RoomId Is null or RoomId = @RoomId) and (Contract.ContractDate between @StartDate and @EndDate )


	--Store get total OutBill For Dashboard
		ALTER Procedure [dbo].[GetOutBillForDashboard]
			@Date nvarchar(50)
			As
			SELECT
			DATEPART(MONTH, Date) AS Month,
			SUM(OutBill.Cost ) AS Total
			FROM
			OutBill where IsDeleted =0 and YEAR(Date)=YEAR(@Date)
			GROUP BY DATEPART(MONTH, Date)
			ORDER BY Month;

	--Store get total InBill For Dashboard
		ALTER Procedure [dbo].[GetInBillForDashboard]
			@Date nvarchar(50)
			As
			SELECT
			DATEPART(MONTH, Date) AS Month,
			SUM(InBill.Cost ) AS Total
			FROM
			InBill where IsDeleted =0 and YEAR(Date)=YEAR(@Date)
			GROUP BY DATEPART(MONTH, Date)
			ORDER BY Month;

	--Store get total Invoice For Dashboard
	ALTER Procedure [dbo].[GetInvoiceForDashboard]
		@Date nvarchar(50)
		As
		SELECT
		DATEPART(MONTH, Month) AS Month,
		SUM((ElecNew-ElecOld)*ElecUnit+(WarNew-WarOld)*WarUnit) AS Total
		FROM
		Invoice where IsDeleted =0 and YEAR(Month)=YEAR(@Date)
		GROUP BY DATEPART(MONTH, Month)
		ORDER BY Month;

	--Store get total Contract For Dashboard
		CREATE Procedure [dbo].[GetContractForDashboard]
			@Date nvarchar(50)
			As
			SELECT
			DATEPART(MONTH, ContractDate) AS Month,
			COUNT(*) AS Total
			FROM Contract
			where YEAR(ContractDate)=YEAR(@Date) and IsDeleted=0
			GROUP BY
			DATEPART(MONTH, ContractDate)
			ORDER BY
			DATEPART(MONTH, ContractDate)


	-- update 06/12/2022

	
	--Store get list Room for create Invoice
		CREATE Procedure GetListRoomForCreateInvoice
			As
			Begin
			Select Id,RoomNo from Room where IsDeleted = 0 and Id Not In 
			(Select Room.Id From Room inner join Invoice on Room.Id = Invoice.RoomId 
			Where MONTH(Invoice.Month)=MONTH(GetDate()) and YEAR(Invoice.Month)=YEAR(GetDate()))
			End

	-- update 07/12/2022
	--create procrdure update isRoom=0 and Amount=Amount-1 when Contract.EndDate <= GetDAte()
		CREATE PROCEDURE contract_timeout
			AS
			BEGIN 
				DECLARE @RoomId int
				DECLARE cursorContract CURSOR FOR
				SELECT RoomId FROM dbo.Contract WHERE EndDate < GETDATE() AND IsDeleted =0
				Open cursorContract
				FETCH NEXT FROM cursorContract     -- Đọc dòng đầu tiên
				  INTO @RoomId
				  WHILE @@FETCH_STATUS = 0          --vòng lặp WHILE khi đọc Cursor thành công
					BEGIN
						UPDATE dbo.Room SET Amount = (Select Count(Id) from Contract where IsDeleted =0 and RoomId = @RoomId AND dbo.Contract.EndDate >= GETDATE()) WHERE Id = @RoomId
					FETCH NEXT FROM cursorContract -- Đọc dòng tiếp
					  INTO @RoomId
					END
				CLOSE cursorContract              -- Đóng Cursor
				DEALLOCATE cursorContract 
				UPDATE dbo.Student SET	IsRoom = 0 WHERE Id IN (SELECT StudentId FROM dbo.Contract WHERE EndDate < GETDATE() AND IsDeleted =0)
			END
	-- Create store get list student in a room
		CREATE PROCEDURE GetListStudentInRoom
		@RoomId int
			AS
			BEGIN
			select Student.Id, Student.Name as Name, Gender, StudentNo, Cmnd, Phone from Student
			INNER JOIN Contract on Student.Id =Contract.StudentId
			where RoomId = @RoomId and Student.IsDeleted=0 and Contract.IsDeleted=0 and	Contract.EndDate>=GETDATE()
			END

	-- update 09/12/2022
	--Store get list room for create contract
		ALTER Procedure [dbo].[GetListRoomForConTract]
		@StudentId int
		As
		begin
			Declare @Gender int 
			Set @Gender = (Select Gender From Student where id = @StudentId)
			select Room.Id,RoomNo,UnitPrice,Maxx-Amount AS Empty from Room 
			left join Contract on Room.Id = Contract.RoomId 
			left join Student on Student.Id = Contract.StudentId
			where Amount<Maxx and Room.Id Not In (select RoomId from contract inner join student on contract.studentId = Student.Id where gender <>@Gender)
			GROUP BY Room.Id,RoomNo,UnitPrice,Maxx-Amount
			ORDER BY Empty
		END
	-- update 12/12/2022 
	-- Create job update amount of room and status of student when contract time out
		USE [msdb]
			GO

			/****** Object:  Job [job_contract_timeout]    Script Date: 12/12/2022 12:21:11 PM ******/
			BEGIN TRANSACTION
			DECLARE @ReturnCode INT
			SELECT @ReturnCode = 0
			/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 12/12/2022 12:21:11 PM ******/
			IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
			BEGIN
			EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
			IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

			END

			DECLARE @jobId BINARY(16)
			EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'job_contract_timeout', 
					@enabled=1, 
					@notify_level_eventlog=0, 
					@notify_level_email=0, 
					@notify_level_netsend=0, 
					@notify_level_page=0, 
					@delete_level=0, 
					@description=N'No description available.', 
					@category_name=N'[Uncategorized (Local)]', 
					@owner_login_name=N'sa', @job_id = @jobId OUTPUT
			IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
			/****** Object:  Step [contract_timeout]    Script Date: 12/12/2022 12:21:11 PM ******/
			EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'contract_timeout', 
					@step_id=1, 
					@cmdexec_success_code=0, 
					@on_success_action=1, 
					@on_success_step_id=0, 
					@on_fail_action=2, 
					@on_fail_step_id=0, 
					@retry_attempts=0, 
					@retry_interval=0, 
					@os_run_priority=0, @subsystem=N'TSQL', 
					@command=N'exec contract_timeout', 
					@database_name=N'DormitoryDB', 
					@flags=0
			IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
			EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
			IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
			EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'CollectorSchedule_Every_15min', 
					@enabled=1, 
					@freq_type=4, 
					@freq_interval=1, 
					@freq_subday_type=4, 
					@freq_subday_interval=15, 
					@freq_relative_interval=0, 
					@freq_recurrence_factor=0, 
					@active_start_date=20190924, 
					@active_end_date=99991231, 
					@active_start_time=0, 
					@active_end_time=235959, 
					@schedule_uid=N'b4829dad-5f2b-4e14-94b0-ccba6ba75bea'
			IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
			EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
			IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
			COMMIT TRANSACTION
			GOTO EndSave
			QuitWithRollback:
				IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
			EndSave:
			GO

	--update 9/2/2023
	-- get total monry of contract 
			ALTER Procedure GetTotalMoneyContract
			@Date nvarchar(50)
			As
			SELECT
			DATEPART(MONTH, ContractDate) AS Month,
			SUM(Room.UnitPrice) AS TotalMoney
			FROM Contract 
			INNER JOIN Room ON Contract.RoomId=Room.Id
			where YEAR(ContractDate)=YEAR(@Date) and Contract.IsDeleted=0
			GROUP BY
			DATEPART(MONTH, ContractDate)
			ORDER BY
			DATEPART(MONTH, ContractDate)
        --set contract timeout
		ALTER PROCEDURE [dbo].[contract_timeout]
			AS
			BEGIN 
				DECLARE @RoomId int
				DECLARE cursorContract CURSOR FOR
				SELECT RoomId FROM dbo.Contract WHERE EndDate < GETDATE() AND IsDeleted =0
				Open cursorContract
				FETCH NEXT FROM cursorContract     -- Đọc dòng đầu tiên
				  INTO @RoomId
				  WHILE @@FETCH_STATUS = 0          --vòng lặp WHILE khi đọc Cursor thành công
					BEGIN
						UPDATE dbo.Room SET Amount = (Select Count(Id) from Contract where IsDeleted =0 and RoomId = @RoomId AND dbo.Contract.EndDate >= GETDATE()) WHERE Id = @RoomId
					FETCH NEXT FROM cursorContract -- Đọc dòng tiếp
					  INTO @RoomId
					END
				CLOSE cursorContract              -- Đóng Cursor
				DEALLOCATE cursorContract 
				UPDATE dbo.Student SET	IsRoom = 0 WHERE Id IN (SELECT StudentId FROM dbo.Contract WHERE EndDate < GETDATE() AND IsDeleted =0)
			END
