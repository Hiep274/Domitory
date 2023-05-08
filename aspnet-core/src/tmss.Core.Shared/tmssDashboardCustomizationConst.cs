namespace tmss
{
    public class tmssDashboardCustomizationConsts
    {
        /// <summary>
        /// Main page name your user will see if they dont change default page's name.
        /// </summary>
        public const string DefaultPageName = "Default Page";

        //Must use underscore instead of dot in widget and filter ids
        //(these data are also used as ids in the input in html pages. Please provide appropriate values.)
        public class Widgets
        {
            public class Tenant
            {
                public const string ProfitShare = "Widgets_Tenant_ProfitShare";
                public const string OverviewDataTable = "Widgets_Tenant_OverViewDataTable";
                public const string RateOfChange = "Widgets_Rate_Of_Change";
                public const string ReasonOfLost = "Widgets_Tenant_ReasonOfLost";
                public const string Source = "Widgets_Tenant_Source";
                public const string SalesProcess = "Widgets_Tenant_SalesProcess";
                public const string TargetActualQty = "Widgets_Tenant_TargetAcutalQty";
                public const string VehicleModel = "Widgets_Tenant_VehicleModel";
                public const string DetailPotentialCustomers = "Widgets_Tenant_Detail_Potential_Customers";
                public const string ConversionRate = "Widgets_Tenant_ConversionRate";
                public const string ConversionRateSalesPerson = "Widgets_Tenant_ConversionRateSalesPerson";
                public const string Province = "Widgets_Tenant_Province";
                public const string District = "Widgets_Tenant_District";
                public const string SourceInfor = "Widgets_Tenant_SourceInfor";
                public const string TransitionStatus = "Widgets_Tenant_TransitionStatus";
                public const string LocateSalesPerson = "Widgets_Tenant_LocateSalesPerson";
                public const string CustomersSold = "Widgets_Tenant_CustomersSold";
                public const string PaymentMethodOfCustomer = "Widgets_Tenant_PaymentMethodOfCustomer";
                public const string DistricOfCustomer = "Widgets_Tenant_DistricOfCustomer";
                public const string ProvinceOfCustomer = "Widgets_Tenant_ProvinceOfCustomer";
                public const string ProcessOfCustomer = "Widgets_Tenant_ProcessOfCustomer";
                public const string SourceOfCustomer = "Widgets_Tenant_SourceOfCustomer";
                public const string VehicleModelOfCustomer = "Widgets_Tenant_VehicleModelOfCustomer";
                public const string AverageConversionTime = "Widgets_Tenant_AverageConversionTime";
                public const string AverageContactTime = "Widgets_Tenant_AverageContactTime";
                public const string ListCustomer = "Widgets_Tenant_ListCustomer";
                public const string SourceInforOfCustomer = "Widgets_Tenant_SourceInforOfCustomer";
                public const string FollowActivitySalesPerson = "Widgets_Tenant_FollowActivitySalesPerson";
                public const string ListSoldCar = "Widgets_Tenant_ListSoldCar";
                public const string NumberOfConversions = "Widgets_Tenant_NumberOfConversions";
                public const string NumberInquiryOverMonthForDealer = "Widgets_Tenant_NumberInquiryOverMonthForDealer";
                public const string ResultConversionOverMonthForDealer = "Widgets_Tenant_ResultConversionOverMonthForDealer";
                public const string ListInquiryFromTMVForDealer = "Widgets_Tenant_ListInquiryFromTMVForDealer";
                public const string StatisticsInquiryOverGroupForDealer = "Widgets_Tenant_StatisticsInquiryOverGroupForDealer"; 
                public const string VehicleSalesPerson = "Widgets_Tenant_VehicleSalesPerson";
                public const string StructureGeneralCustomer = "Widgets_Tenant_StructureGeneralCustomer"; 
                public const string GereralCustomerByDept = "Widgets_Tenant_GereralCustomerByDept";
                public const string GereralCustomerByWeek = "Widgets_Tenant_GereralCustomerByWeek";
                public const string GereralCustomerByMonth = "Widgets_Tenant_GereralCustomerByMonth";
                public const string StructureSourceCustomer = "Widgets_Tenant_StructureSourceCustomer"; 
                public const string SummarySourceCustomer = "Widgets_Tenant_SummarySourceCustomer";
                public const string SummaryVehicleCustomer = "Widgets_Tenant_SummaryVehicleCustomer";
                public const string LostVehicleCustomer = "Widgets_Tenant_LostVehicleCustomer"; 
                public const string GroupCustomerDRA = "Widgets_Tenant_GroupCustomerDRA";
                public const string GroupCustomerProvince = "Widgets_Tenant_GroupCustomerProvince";
                public const string CustomerPRMSource = "Widgets_Tenant_CustomerPRMSource";
                public const string CustomerPRMModel = "Widgets_Tenant_CustomerPRMModel";
                public const string CustomerPRMSourceModel = "Widgets_Tenant_CustomerPRMSourceModel";
                public const string ContactDetailHwc = "Widgets_Tenant_ContactDetailHwc";
                public const string ContactGeneralHwc = "Widgets_Tenant_ContactGeneralHwc";
                public const string MovementImCwd = "Widgets_Tenant_MovementImCwd";
                public const string MovementSale = "Widgets_Tenant_MovementSale";
                public const string CwdPlanByModel = "Widgets_Tenant_CwdPlanByModel";
                public const string SaleActualPlanByModel = "Widgets_Tenant_SaleActualPlanByModel";
                public const string CwdPlanByDayOrWeekly = "Widgets_Tenant_CwdPlanByDayOrWeekly";
                public const string SalePlanByDayOrWeekly = "Widgets_Tenant_SalePlanByDayOrWeekly";
                public const string DetailByModelGrade = "Widgets_Tenant_DetailByModelGrade";
                public const string ImConversionTotalByHotness = "Widgets_Tenant_ImConversionTotalByHotness";
                public const string ConversionCwdByHotness = "Widgets_Tenant_ConversionCwdByHotness";
                public const string ConvesionRateByHotness = "Widgets_Tenant_ConvesionRateByHotness";
                public const string TotalLossReason = "Widgets_Tenant_TotalLossReason";
                public const string LossByModel = "Widgets_Tenant_LossByModel";
                public const string LossByPrivateReasons = "Widgets_Tenant_LossByPrivateReasons";
                public const string LossByOtherDlrsReasons = "Widgets_Tenant_LossByOtherDlrsReasons";
                public const string LossByOtherMakerReasons = "Widgets_Tenant_LossByOtherMakerReasons";
                public const string CustomerBySourceTotal = "Widgets_Tenant_CustomerBySourceTotal";
                public const string CustomerBySalepersonSource = "Widgets_Tenant_CustomerBySalepersonSource";
                public const string CustomerByDealerSource = "Widgets_Tenant_CustomerByDealerSource";
                public const string CustomerByTmvSource = "Widgets_Tenant_CustomerByTmvSource";
                public const string CustomerByTotalModels = "Widgets_Tenant_CustomerByTotalModels";
                public const string NewCustomerByGrade = "Widgets_Tenant_NewCustomerByGrade";
                public const string RemainingCustomerByGrade = "Widgets_Tenant_RemainingCustomerByGrade";
                public const string AllCustomerByHotness = "Widgets_Tenant_AllCustomerByHotness";
                public const string AllOfCustomerByModel = "Widgets_Tenant_AllOfCustomerByModel";
                public const string ActualAndCwdWithPlanByModel = "Widgets_Tenant_ActualAndCwdWithPlanByModel";
                public const string FollowActivitySalesPersonFirst = "Widgets_Follow_Activity_Sale_Person_First";
                public const string FollowActivitySalesPersonSecond = "Widgets_Follow_Activity_Sale_Person_Second";
            }

            public class Host
            {
                public const string ProfitShareHost = "Widgets_Host_ProfitShare";
                public const string OverviewDataTableHost = "Widgets_Host_OverViewDataTable";
                public const string RateOfChangeHost = "Widgets_Rate_Of_Change";
                public const string ReasonOfLostHost = "Widgets_Host_ReasonOfLost";
                public const string SourceHost = "Widgets_Host_Source";
                public const string SalesProcessHost = "Widgets_Host_SalesProcess";
                public const string TargetActualQtyHost = "Widgets_Host_TargetAcutalQty";
                public const string VehicleModelHost = "Widgets_Host_VehicleModel";
                public const string DetailPotentialCustomersHost = "Widgets_Host_Detail_Potential_Customers";
                public const string ConversionRateHost = "Widgets_Host_ConversionRate";
                public const string ProvinceHost = "Widgets_Host_Province";
                public const string DistrictHost = "Widgets_Host_District";
                public const string SourceInforHost = "Widgets_Host_SourceInfor";
                public const string TransitionStatusHost = "Widgets_Host_TransitionStatus";
                public const string CustomersSoldHost = "Widgets_Host_CustomersSold";
                public const string PaymentMethodOfCustomerHost = "Widgets_Host_PaymentMethodOfCustomer";
                public const string DistricOfCustomerHost = "Widgets_Host_DistricOfCustomer";
                public const string ProvinceOfCustomerHost = "Widgets_Host_ProvinceOfCustomer";
                public const string ProcessOfCustomerHost = "Widgets_Host_ProcessOfCustomer";
                public const string SourceOfCustomerHost = "Widgets_Host_SourceOfCustomer";
                public const string VehicleModelOfCustomerHost = "Widgets_Host_VehicleModelOfCustomer";
                public const string AverageConversionTimeHost = "Widgets_Host_AverageConversionTime";
                public const string AverageContactTimeHost = "Widgets_Host_AverageContactTime";
                public const string ListCustomerHost = "Widgets_Host_ListCustomer";
                public const string SourceInforOfCustomerHost = "Widgets_Host_SourceInforOfCustomer";
                public const string NumberOfConversionsHost = "Widgets_Host_NumberOfConversions";
                public const string NumberInquiryOfMonthHost = "Widgets_Host_NumberInquiryOfMonth";
                public const string ConversionRateOverMonthHost = "Widgets_Host_ConversionRateOverMonth";
                public const string ConversionSourceOverMonth = "Widgets_Host_ConversionSourceOverMonth";
                public const string StatisticsInquiryOverDealer = "Widgets_Host_StatisticsInquiryOverDealer";
                public const string ResultConversionOverMonth = "Widgets_Host_ResultConversionOverMonth";
                public const string ListInquiryFromTMV = "Widgets_Host_ListInquiryFromTMV";
                public const string InquiryTMVReasonOfNC = "Widgets_Host_InquiryTMVReasonOfNC";
                public const string LeadByAge = "Widgets_Host_LeadByAge";
                public const string WeeklyTrackingByAge = "Widgets_Host_WeeklyTrackingByAge";
                public const string NewlyAddedLeadStatusBySource = "Widgets_Host_NewlyAddedLeadStatusBySource";
                public const string NewlyAddedLeadStatusByRegion = "Widgets_Host_NewlyAddedLeadStatusByRegion";
                public const string NewlyAddedLeadStatusByRegionAndSource = "Widgets_Host_NewlyAddedLeadStatusByRegionAndSource"; 
                public const string ViewContactedBySource = "Widgets_Host_ViewContactedBySource";
                public const string ViewSuccessContactedBySource = "Widgets_Host_ViewSuccessContactedBySource";
                public const string ContactAndContactSuccessRate = "Widgets_Host_ContactAndContactSuccessRate";
                public const string ConversionRateOfInquiryToSR = "Widgets_Host_ConversionRateOfInquiryToSR";
                public const string VehicleSalesPersonHost = "Widgets_Host_VehicleSalesPerson";
                public const string RankingByDealers = "Widgets_Host_RankingByDealers"; 
                public const string AverageLeadTimeFromGeneration = "Widgets_Host_AverageLeadTimeFromGeneration"; 
                public const string LeadTimeByDealersFromGeneration = "Widgets_Host_LeadTimeByDealersFromGeneration";
                public const string DeepDiveAnalysisListOfSelectedLeadsCWD = "Widgets_Host_DeepDiveAnalysisListOfSelectedLeadsCWD";
                public const string DeepDiveAnalysisListOfSelectedLeadsInquiry = "Widgets_Host_DeepDiveAnalysisListOfSelectedLeadsInquiry";
                public const string DeepDiveAnalysisListOfSelectedLeadsContactedFailed = "Widgets_Host_DeepDiveAnalysisListOfSelectedLeadsContactedFailed";
                public const string ConversionRateForTMV = "Widgets_Host_ConversionRateForTMV";
                public const string LocateDealerForTMV = "Widgets_Host_LocateDealerForTMV";
                public const string StatisticsInquiryOverMonthForTmv = "Widgets_Host_StatisticsInquiryOverMonthForTmv";
                public const string MovementImCwdForTMV = "Widgets_Host_MovementImCwd";
                public const string AllOfCustomerByModelForTmv = "Widgets_Host_AllOfCustomerByModelForTmv";
                public const string AllCustomerByHotnessForTmv = "Widgets_Host_AllCustomerByHotnessForTmv";
                public const string CustomerBySourceTotalForTmv = "Widgets_Host_CustomerBySourceTotalForTmv";
                public const string CustomerBySalepersonSourceForTmv = "Widgets_Host_CustomerBySalepersonSourceForTmv";
                public const string CustomerByDealerSourceForTmv = "Widgets_Host_CustomerByDealerSourceForTmv";
                public const string CustomerByTmvSourceForTmv = "Widgets_Host_CustomerByTmvSourceForTmv";
                public const string TotalLossReasonForTmv = "Widgets_Host_TotalLossReasonForTmv";
                public const string LossByPrivateReasonsForTmv = "Widgets_Host_LossByPrivateReasonsForTmv";
                public const string LossOtherDlrsReasonForTmv = "Widgets_Host_LossOtherDlrsReasonForTmv";
                public const string LossByOttherMakerReasonsForTmv = "Widgets_Host_LossByOttherMakerReasonsForTmv";
                public const string LossByModelForTmv = "Widgets_Host_LossByModelForTmv";
                public const string ContractGeneralHwcForTmv = "Widgets_Host_ContractGeneralHwcForTmv";
                public const string FollowActivitySalesPrsonForTmv = "Widgets_Host_FollowActivitySalesPrsonForTmv";
                public const string FollowActivitySalesPersonSecondForTmv = "Widgets_Host_FollowActivitySalesPersonSecondForTmv";
                public const string FollowActivitySalesPersonFirstForTmv = "Widgets_Host_FollowActivitySalesPersonFirstForTmv";
                public const string CustomerByTotalModelForTmv = "Widgets_Host_CustomerByTotalModelForTmv";
                public const string RemainingCustomerByGradeForTmv = "Widgets_Host_RemainingCustomerByGradeForTmv";
                public const string NewCustomerByGradeForTmv = "Widgets_Host_NewCustomerByGradeForTmv";
                public const string ImConversionTotalByHotnessForTmv = "Widgets_Host_ImConversionTotalByHotnessForTmv";
                public const string ConversionCwdByHotnessForTmv = "Widgets_Host_ConversionCwdByHotnessForTmv";
                public const string ConversionRateByHotnessForTmv = "Widgets_Host_ConversionRateByHotnessForTmv";
            }
        }

        public class Filters
        {
            public const string FilterDateRangePicker = "Filters_DateRangePicker";
            public const string WidgetFilter = "Filters_Widget";
        }

        public class DashboardNames
        {
            public const string DefaultTenantDashboard = "TenantDashboard";

            public const string DefaultHostDashboard = "HostDashboard";
        }

        public class Applications
        {
            public const string Mvc = "Mvc";
            public const string Angular = "Angular";
        }
    }
}
