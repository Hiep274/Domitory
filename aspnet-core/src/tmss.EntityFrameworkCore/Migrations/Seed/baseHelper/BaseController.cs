using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using tmss.EntityFrameworkCore;

namespace tmss.Migrations.Seed.baseHelper
{
    public class BaseController
    {
        protected readonly tmssDbContext _context;
        public long[] AllMstSleCustomerTypeID;
        public long[] AllMstGenProvinceID;
        public long[] AllMstSleDistrictID;
        public long[] AllMstSleHotnessID;
        public long[] AllMstSleExpectedDelTimingID;
        public long[] AllMstSleSalePersonID;
        public long[] AllMstSleSourceID;
        public long[] AllMstSlePaymentTypeID;
        public long[] AllMstSleGenderID;
        public long[] AllMstSleMaritalStatusID;
        public long[] AllMstSleOccupationID;
        public long[] AllMstSleHobbyID;
        public long[] AllMstSleSourceOfInfoID;
        public long[] AllMstSleFARID;
        public long[] AllMstSlePurposeID;
        public long[] AllMstSleAgeRangeID;
        public long[] AllMstSleRelationshipID;
        public long[] AllSalesCustomerID;
        public long[] AllMstSleSocialChannelID;
        public long[] AllMstSleSalesStageID;
        public long[] AllMstSleActivityStatusID;
        public long[] AllMstSleReasonofLostID;
        public long[] AllMstSleDeliveryPlaceID;
        public long[] AllMstSleRouteID;
        public long[] AllMstSleSupportersID;
        public long[] AllSalesCustomerTransactionInfoID;
        public long[] AllMstSleAppActivityID;
        public long[] AllMstSleAppPlaceID;
        public long[] AllMstSleContactByID;
        public long[] AllMstSleActionID;
        public long[] AllSalesCustomerTransactionInfoContactID;
        public long[] AllMstSleModelID;
        public long[] AllMstSleGradesID;
        public long[] AllMstSleColorGradesProductionID;
        public long[] AllMstSleColorsID;
        public long[] AllSalesVehicleId;
        public long[] ALLVehicleTypeId;

        public BaseController(tmssDbContext context)
        {
            _context = context;
         
            ALLVehicleTypeId = getAllVehicleTypeId();
        }
      
        public long[] getAllVehicleTypeId()
        {
            long[] res = new long[] { 1, 2, 3 };
            return res;
        }

        public long randomValue(long[] arr)
        {
            if (arr.Count() == 0)
            {
                return 0;
            }
            int index = new Random().Next(0, arr.Count());

            return arr[index];
        }



    }
};